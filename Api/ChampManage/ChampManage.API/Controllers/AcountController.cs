using ChampManage.API.Data;
using ChampManage.API.Entities;
using ChampManage.API.Models.AuthenticationModels;
using ChampManage.API.Models.UserModels;
using ChampManage.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;

namespace ChampManage.API.Controllers
{
    /// <summary>
    /// API endpoints for managing user accounts.
    /// </summary>
    [Route("api/account")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class AcountController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        public AcountController(IUserRepository userRepository,
                                ITokenService tokenService,
                                IConfiguration configuration)
        {
            _userRepository = userRepository ??
                 throw new ArgumentNullException(nameof(userRepository));
            _tokenService = tokenService ??
                 throw new ArgumentNullException(nameof(tokenService));
            _configuration = configuration ??
                 throw new ArgumentNullException(nameof(tokenService));
        }

        /// <summary>
        /// Registers a new user account.
        /// </summary>
        /// <param name="userRegisterDto">The data for the new user account.</param>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserAuthResultDto>> Register (UserRegistrationDto userRegisterDto)
        {
            // Check if the email is unique
            bool isEmailUnique = await _userRepository.IsEmailUniqueAsync(userRegisterDto.Email);

            if (!isEmailUnique)
            {
                return BadRequest("Email is not unique.");
            }

            using var hmac = new HMACSHA256();

            var user = new User(userRegisterDto.FirstName, userRegisterDto.LastName, userRegisterDto.Email)
            {
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userRegisterDto.Password)),
                PasswordSalt = hmac.Key
            };

            if (user.Email.Equals(_configuration["AdminEmail"]))
            {
                user.UserType = UserType.Admin;
            }

            await _userRepository.CreateUserAsync(user);
            await _userRepository.SaveChangesAsync();

            var userToReturn = new UserAuthResultDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            };

            return Ok(userToReturn);
        }

        /// <summary>
        /// Logs in a user.
        /// </summary>
        /// <param name="loginDto">The login credentials.</param>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserAuthResultDto>> Login (LoginCredentialsDto loginDto)
        {
            var user = await _userRepository.GetUserByEmailAsync(loginDto.Email);

            if (user == null) 
            {  
                return Unauthorized("Invalid email address"); 
            }

            using var hmac = new HMACSHA256(user.PasswordSalt);
            
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password)); 

            for (int i = 0; i < computedHash.Length; i++)
            {
                if(computedHash[i] != user.PasswordHash[i])
                {
                    return Unauthorized("Invalid Password");
                }
            }

            var userToReturn = new UserAuthResultDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            };

            return Ok(userToReturn);
        }
    }
}
