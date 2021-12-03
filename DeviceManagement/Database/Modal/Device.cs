using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement.Database.Modal
{
    public class Device
    {
        public int deviceId { get; set; }
        public string deviceName { get; set; }
        public string deviceStatus { get; set; }
        public int deviceTemperature { get; set; }
        public string deviceUsage { get; set; }
        public byte[] deviceThumbnail { get; set; }
    }
}
