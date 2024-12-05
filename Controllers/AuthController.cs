using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using jwtauth.DTOs;
using jwtauth.Models;
using jwtauth.Repositories;
using jwtauth.Services;
using Microsoft.AspNetCore.Mvc;

namespace jwtauth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly JwtService jwtService;
        private readonly IMapper mapper;

        public AuthController(IUserRepository userRepository, JwtService jwtService, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.jwtService = jwtService;
            this.mapper = mapper;
        }

        [HttpPost("register")]
         public async Task<IActionResult> Register(RegisterUserDto registerDto)
         {
            var user = mapper.Map<User>(registerDto);
            await userRepository.RegisterUserAsync(user, registerDto.Password);
            return Ok();
        }

        [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserDto loginDto)
    {
        if (!await userRepository.ValidateUserAsync(loginDto.Username, loginDto.Password))
            return Unauthorized();

        var user = await userRepository.GetUserByUsernameAsync(loginDto.Username);
        var token = jwtService.GenerateJwtToken(user);
        return Ok(new { Token = token });
    }
    }
}