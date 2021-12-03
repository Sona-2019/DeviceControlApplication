using DeviceManagement.DTO;
using DeviceManagement.QueryService;
using DeviceManagement.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeviceManagement.Controller
{
  
    [ApiController]
    public class DeviceController : ControllerBase
    {
        

        #region :::variables:::
        ///<summary>
        ///private interface variables
        ///</summary>
        ///
        private readonly IDeviceControlQueryService queryService;
        private readonly ILogger<DeviceController> logger;
        //private readonly IMapper mapper;

        #endregion
        #region :::Constructor:::
        ///<summary>
        ///Constructor of Device Controller 
        ///</summary>
        ///<param name="queries"></param>
        public DeviceController(IDeviceControlQueryService queries, ILogger<DeviceController> loggerparam)

        {
            this.queryService = queries ?? throw new ArgumentNullException(nameof(queries));
            this.logger = loggerparam;

        }


        #endregion
        #region :::API:::
        /// <summary>
        /// API to get All Device Data
        /// </summary>
        /// <returns><see cref="DeviceDataDTO"/></returns>
        [Route("api/Device/GetAllDeviceList")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(DeviceDataDTO), (int)HttpStatusCode.OK)]
        [HttpGet]
        public async Task<IActionResult> GetAllDeviceList()
        {
            ResultToReturn<List<DeviceDataDTO>> deviceDataList = new ResultToReturn<List<DeviceDataDTO>>();
            try
            {
                List<DeviceDataDTO> deviceList = new List<DeviceDataDTO>();
                deviceList = await queryService.GetAllDeviceDataList();
                if (deviceList != null)
                {
                    deviceDataList.ReturnedResult = deviceList;
                    deviceDataList.Status = ActionStatus.Success;
                }
                else
                {
                    deviceDataList.Message = "Oops..Something Went Wrong...Pls try again later";
                    deviceDataList.Status = ActionStatus.Failed;
                }
            }
            catch (Exception exp)
            {
                deviceDataList.Status = ActionStatus.Error;
                //log error
                this.logger.LogError(exp, "Exception Caught");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while getting Device Data");

            }
            return Ok(deviceDataList);
        }

        /// <summary>
        /// API to get Device Data by DeviceId
        /// </summary>
        /// <returns><see cref="DeviceDataDTO"/></returns>
        [Route("api/Device/GetDeviceDataById/{deviceId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(DeviceDataDTO), (int)HttpStatusCode.OK)]
        [HttpGet]
        public async Task<IActionResult> GetDeviceById(int deviceId)
        {
            ResultToReturn<DeviceDataDTO> deviceData = new ResultToReturn<DeviceDataDTO>();
            try
            {
                DeviceDataDTO deviceList = new DeviceDataDTO();
                deviceList = await queryService.GetDeviceDataById(deviceId);
                if (deviceList != null)
                {
                    deviceData.ReturnedResult = deviceList;
                    deviceData.Status = ActionStatus.Success;
                }
                else
                {
                    deviceData.Message = "Oops..Something Went Wrong...Pls try again later";
                    deviceData.Status = ActionStatus.Failed;
                }
            }
            catch (Exception exp)
            {
                deviceData.Status = ActionStatus.Error;
                //log error
                this.logger.LogError(exp, "Exception Caught");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while getting Device data");

            }
            return Ok(deviceData);
        }

        /// <summary>
        /// API to get All Related Device Data by Selected Device
        /// </summary>
        /// <returns><see cref="DeviceDataDTO"/></returns>
        [Route("api/Device/GetDeviceRelatedDataById/{deviceId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(DeviceDataDTO), (int)HttpStatusCode.OK)]
        [HttpGet]
        public async Task<IActionResult> GetAllRelatedDeviceList(int deviceId)
        {
            ResultToReturn<List<DeviceDataDTO>> relatedDeviceList = new ResultToReturn<List<DeviceDataDTO>>();
            try
            {
                List<DeviceDataDTO> deviceList = new List<DeviceDataDTO>();
                deviceList = await queryService.GetRelatedDeviceList(deviceId);
                if (deviceList != null)
                {
                    relatedDeviceList.ReturnedResult = deviceList;
                    relatedDeviceList.Status = ActionStatus.Success;
                }
                else
                {
                    relatedDeviceList.Message = "Oops..Something Went Wrong...Pls try again later";
                    relatedDeviceList.Status = ActionStatus.Failed;
                }
            }
            catch (Exception exp)
            {
                relatedDeviceList.Status = ActionStatus.Error;
                //log error
                this.logger.LogError(exp, "Exception Caught");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while getting Device Data");

            }
            return Ok(relatedDeviceList);
        }
    }

    #endregion


}
