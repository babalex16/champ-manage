using ChampManage.API.Data;
using ChampManage.API.Entities;
using ChampManage.API.Models;
using ChampManage.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace ChampManage.API.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AcountController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AcountController(IUserRepository userRepository,
                                ITokenService tokenService)
        {
            _userRepository = userRepository ??
                 throw new ArgumentNullException(nameof(userRepository));
            _tokenService = tokenService ??
                 throw new ArgumentNullException(nameof(tokenService));
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserLogInDto>> Register (UserRegisterDto userRegisterDto)
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

            await _userRepository.CreateUserAsync(user);
            await _userRepository.SaveChangesAsync();

            var userToReturn = new UserLogInDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            };

            return userToReturn;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserLogInDto>> Login (LoginDto loginDto)
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

            var userToReturn = new UserLogInDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            };

            return userToReturn;
        }
    }
}
