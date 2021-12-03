using DeviceManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement.QueryService
{
    public interface IDeviceControlQueryService
    {
        Task<List<DeviceDataDTO>> GetAllDeviceDataList();
        Task<DeviceDataDTO> GetDeviceDataById(int deviceID);
        Task<List<DeviceDataDTO>> GetRelatedDeviceList(int deviceID);
    }
}
