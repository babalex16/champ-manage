﻿using AutoMapper;
using ChampManage.API.Entities;
using ChampManage.API.Models;
using ChampManage.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChampManage.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository,
                                IMapper mapper)
        {
            _userRepository = userRepository ??
                throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers() 
        {   
            var userEntities = await _userRepository.GetUsersAsync();

            return Ok(_mapper.Map<IEnumerable<UserDto>>(userEntities));
        }

        [HttpGet("{userId}", Name = "GetUser")]
        public async Task<ActionResult<UserDto>> GetUser(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if ( user == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UserDto>(user));
        }
        
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser (
                    UserForCreationDto userForCreationDto)
        {
            if (userForCreationDto == null)
            {
                return BadRequest();
            }

            // Check if the email is unique
            bool isEmailUnique = await _userRepository.IsEmailUniqueAsync(userForCreationDto.Email);

            if (!isEmailUnique)
            {
                return BadRequest("Email is not unique.");
            }

            var userToCreate = _mapper.Map<User>(userForCreationDto);

            await _userRepository.CreateUserAsync(userToCreate);

            await _userRepository.SaveChangesAsync();

            var createdUserDtoToReturn = _mapper.Map<UserDto>(userToCreate);

            return CreatedAtRoute("GetUser", 
                new 
                { 
                    userId = createdUserDtoToReturn.Id
                },
                createdUserDtoToReturn);
        }
    }
}
