using ChampManage.API.Data;
using ChampManage.API.Entities;
using ChampManage.API.Models;
using ChampManage.API.Services;
using Microsoft.AspNetCore.Http;
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
        public AcountController(IUserRepository userRepository)
        {
            _userRepository = userRepository ??
                 throw new ArgumentNullException(nameof(userRepository));
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register (UserRegisterDto userRegisterDto)
        {
            // Check if the email is unique
            bool isEmailUnique = await _userRepository.IsEmailUniqueAsync(userRegisterDto.Email);

            if (!isEmailUnique)
            {
                return BadRequest("Email is not unique.");
            }

            using var hmac = new HMACSHA512();

            var user = new User(userRegisterDto.FirstName, userRegisterDto.LastName, userRegisterDto.Email)
            {
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userRegisterDto.Password)),
                PasswordSalt = hmac.Key
            };

            await _userRepository.CreateUserAsync(user);
            await _userRepository.SaveChangesAsync();

            return user;
        }

    }
}
