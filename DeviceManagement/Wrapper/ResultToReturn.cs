using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement.Wrapper
{
    public class ResultToReturn<T>
    {
        public ActionStatus Status { get; set; }
        public T ReturnedResult { get; set; }
        public string Message { get; set; }
    }
    public enum ActionStatus
    {
        Success, Failed, Error
    }
}
