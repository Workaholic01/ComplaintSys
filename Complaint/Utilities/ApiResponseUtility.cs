using Complaint.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complaint.Services.Utilities
{
    public class ApiResponseUtility
    {
        #region JSONSerialize

        /// <summary>
        /// Deserialize the response
        /// </summary>
        /// <param name="_oResponse">Response</param>
        /// <returns>Deserialized xml</returns>
        public static String JSONSerialize(Object oResponse)
        {
            String strReturn = "";

            try
            {
                strReturn = JsonConvert.SerializeObject(oResponse);
            }
            catch (Exception ex)
            {
                //  PPIC3.PSCA.ITDept.Baseline.API.Logger.Logger Log = new PPIC3.PSCA.ITDept.Baseline.API.Logger.Logger();
                //Logger.Logger.Error(MethodBase.GetCurrentMethod().Name + ":" + " exception: " + ex.Message + ", " + ex.InnerException);
                strReturn = ex.Message;
            }

            return (strReturn);
        }

        #endregion

        #region JSONDeserialize

        /// <summary>
        /// Deserialize the response
        /// </summary>
        /// <param name="_oResponse">Response</param>
        /// <returns>Deserialized xml</returns>
        public static T JsonDeserialize<T>(string jsonString)
        {
            T obj = default(T);

            try
            {
                obj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString);
            }
            catch (Exception ex)
            {
                String strReturn = ex.Message;
                // PPIC3.PSCA.ITDept.Baseline.API.Logger.Logger Log = new PPIC3.PSCA.ITDept.Baseline.API.Logger.Logger();
                // Logger.Logger.Error(MethodBase.GetCurrentMethod().Name + ":" + " exception: " + ex.Message + ", " + ex.InnerException);
            }

            return obj;
        }

        #endregion JSONDeserialize


        public static APIResponse CreateSuccessResponse(Object response)
        {

            APIResponse apiResponse = new APIResponse()
            {
                Message = "Success",
                Code = 0,
                Object = response == null ? "null" : JSONSerialize(response),
                ObjectType = response == null ? "null" : response.GetType().Name
            };

            return apiResponse;
        }
        public static APIResponse CreateSuccessResponse(string message, Object response)
        {
            return new APIResponse()
            {
                Message = message,
                Code = 0,
                Object = response == null ? "null" : JSONSerialize(response),
                ObjectType = response == null ? "null" : response.GetType().Name
            };
        }
        public static APIResponse CreateErrorResponse(string message, Object response)
        {
            return new APIResponse()
            {
                Message = message,
                Code = -1,
                Object = response == null ? "null" : JSONSerialize(response),
                ObjectType = response == null ? "null" : response.GetType().Name
            };
        }
        public static APIResponse CreateErrorResponse(Exception ex)
        {
            string message = "";
            int code = -1;
            var t = ex.GetType().FullName;
            bool isSystemException = (t.StartsWith("System."));
            //PPIC3.PSCA.ITDept.Baseline.API.Logger.Logger Log = new PPIC3.PSCA.ITDept.Baseline.API.Logger.Logger();
            //Logger.Logger.ExceptionLog(ex, "Service Method Exception:" + HttpContext.Current.Request.Url, LoggingTypes.Error);
            if (!isSystemException)
            {
                code = 010;//((CustomException)ex).errorCode;
                if (ex.Message.Equals("SystemError"))
                {
                    message = ex.Message + ":" + ex.InnerException.Message;
                }
                else
                {
                    message = ex.Message;
                }
            }
            else
            {
                message = ex.Message;
            }

            return new APIResponse()
            {
                Message = message,
                Code = code,
                Object = null,
                ObjectType = null
            };
        }

        public static byte[] StringToByte(string value)
        {
            return Encoding.ASCII.GetBytes(value);
        }
        public static string ByteToString(byte[] value)
        {
            return Encoding.ASCII.GetString(value);
        }
    }
}
