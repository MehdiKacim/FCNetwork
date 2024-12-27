using FCNetwork.Application.Services;
using FCNetwork.Common.Security.User;
using FCNetwork.Infrastructure.Data;
using FCNetwork.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FCNetwork.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly UserService _userService;

        public UserController(ILogger<UserController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<UserLoginResponse> Login(UserLoginRequest userLoginRequest)
        {
            return await _userService.AuthenticateAsync(userLoginRequest);
        }


        [HttpPost("register")]
        public async Task<RegisterResponse> Register(RegisterRequest registerRequest)
        {
            return await _userService.RegisterUserAsync(registerRequest);
        }
    }
}
