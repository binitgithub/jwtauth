using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jwtauth.DTOs
{
    public class RegisterUserDto
    {
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    }
}