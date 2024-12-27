using AutoMapper;
using FCNetwork.Common.Device;
using FCNetwork.Infrastructure.Entities;

public class DeviceProfile : Profile
{
    public DeviceProfile()
    {
        CreateMap<Device, DeviceResponse>(); // Existing mapping
        CreateMap<DeviceResponse, Device>(); // Reverse mapping
    }
}