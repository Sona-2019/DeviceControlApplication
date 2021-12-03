using DeviceManagement.Database.Context;
using DeviceManagement.Database.Modal;
using DeviceManagement.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement.QueryService
{
    public class DeviceControlQueryService : IDeviceControlQueryService
    {
        #region :::Public Variable:::
        private readonly DeviceContext context;
        #endregion
        #region :::Constructor:::
        public DeviceControlQueryService(DeviceContext dbContext)
        {
            this.context = dbContext;
        }
        #endregion
        #region Public Query Methods:::
        /// <summary>
        /// This method GetAll Devicelist data from the database
        /// </summary>
        /// <returns>List<DeviceDataDTO></returns>
        public async Task<List<DeviceDataDTO>> GetAllDeviceDataList()
        {
            List<DeviceDataDTO> allDeviceList = new List<DeviceDataDTO>();
            try
            {
                List<Device> devices = new List<Device>();
                devices = await context.Device.ToListAsync();
                foreach (var data in devices)
                {
                    allDeviceList.Add(new DeviceDataDTO() { deviceId = data.deviceId, deviceName = data.deviceName, deviceStatus = data.deviceStatus, deviceTemperature = data.deviceTemperature, deviceUsage = data.deviceUsage });
                }
            }
            catch (Exception exp)
            {

                throw exp;
            }
            return await Task.FromResult(allDeviceList);
        }

        /// <summary>
        /// This method Get Devicedata by Id from the database
        /// </summary>
        /// <returns>DeviceDataDTO</returns>
        public async Task<DeviceDataDTO> GetDeviceDataById(int deviceID)
        {
            DeviceDataDTO deviceData = null;
            try
            {
                Device selectedDevice = new Device();
                selectedDevice = await context.Device.FirstOrDefaultAsync(t => t.deviceId == deviceID);
                deviceData = new DeviceDataDTO() { deviceId = selectedDevice.deviceId, deviceName = selectedDevice.deviceName, deviceStatus = selectedDevice.deviceStatus, deviceTemperature = selectedDevice.deviceTemperature, deviceUsage = selectedDevice.deviceUsage };
            }
            catch (Exception exp)
            {

                throw exp;
            }
            return await Task.FromResult(deviceData);
        }

        /// <summary>
        /// This method Get All Related Devicelist data from the database by Selected Device'ID with same Device Status
        /// </summary>
        /// <returns>List<DeviceDataDTO></returns>
        public async Task<List<DeviceDataDTO>> GetRelatedDeviceList(int deviceID)
        {
            List<DeviceDataDTO> relatedDeviceList = new List<DeviceDataDTO>();
            try
            {
                Device selectedDevice = new Device();
                List<Device> relatedDevices = new List<Device>();

                //Fetching Selected Device from database using deviceId
                selectedDevice = await context.Device.Where(t => t.deviceId == deviceID).FirstOrDefaultAsync();
                //Fetching Related Device List from database based on same status of Selected Device
                relatedDevices = await context.Device.Where(t => t.deviceStatus == selectedDevice.deviceStatus).ToListAsync();

                foreach (var relatedData in relatedDevices)
                {
                    relatedDeviceList.Add(new DeviceDataDTO() { deviceId = relatedData.deviceId, deviceName = relatedData.deviceName, deviceStatus = relatedData.deviceStatus, deviceTemperature = relatedData.deviceTemperature, deviceUsage = relatedData.deviceUsage });
                }
            }
            catch (Exception exp)
            {

                throw exp;
            }
            return await Task.FromResult(relatedDeviceList);
        }
        #endregion
    }
}

