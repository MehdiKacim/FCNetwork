using System.Data;
using FCNetwork.Common.Exceptions;
using FCNetwork.Common.Device;
using FCNetwork.Infrastructure.Entities.Security;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using AutoMapper;
using FCNetwork.Infrastructure.Data;
using FCNetwork.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace FCNetwork.Application.Services
{
    public class DeviceService(AppDbContext context, IMapper mapper)
    {
        public async Task<List<DeviceResponse>> GetAllAsync()
        {
            var devices = await context.Devices.ToListAsync();
            return mapper.Map<List<DeviceResponse>>(devices);
        }
        
        public async Task<DeviceResponse> AddAsync(string deviceName)
        {
            var existingDevice = await context.Devices.FirstOrDefaultAsync(d => d.Name == deviceName);
            if (existingDevice != null)
            {
                throw new DuplicateNameException("Device already exists");
            }
            var device = new Device { Name = deviceName };
            
            var result = await context.Devices.AddAsync(device);
            await context.SaveChangesAsync();
            return mapper.Map<DeviceResponse>(result.Entity);
        }
    }
}