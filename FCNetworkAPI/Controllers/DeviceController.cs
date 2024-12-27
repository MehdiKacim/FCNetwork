using FCNetwork.Application.Services;
using FCNetwork.Common.Device;
using FCNetwork.Common.Security.User;
using FCNetwork.Infrastructure.Data;
using FCNetwork.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FCNetwork.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly DeviceService _deviceService;

        public DeviceController(ILogger<UserController> logger, DeviceService deviceService)
        {
            _logger = logger;
            _deviceService = deviceService;
        }

        [HttpGet("")]
        public async Task<List<DeviceResponse>> AllAsync()
        {
            return await _deviceService.GetAllAsync();
        }

        
        [HttpPost("")]
        public async Task<DeviceResponse> AddAsync(string deviceName)
        {
            return await _deviceService.AddAsync(deviceName);
        }
    }
}
