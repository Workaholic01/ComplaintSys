using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Complaint.Core.ComplaintCore;
using Complaint.Models.Entities;
using Complaint.Services.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Complaint.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintController : ControllerBase
    {

        private IComplaintService _complaintService;

        public ComplaintController(IComplaintService complaintService)
        {
            _complaintService = complaintService;
        }
        

        // GET: api/Complaint/5
        [HttpPost]
        [Route("/Complaint/{id}")]
        public string Get(int id)
        {
            try
            {
                var item = _complaintService.FindById(id);
                return JsonConvert.SerializeObject(ApiResponseUtility.CreateSuccessResponse(item));
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ApiResponseUtility.CreateErrorResponse(ex));
            }
        }

        // POST: api/Complaint
        [HttpPost]
        [Route("/Complaint/Log")]
        public string Post(ComplaintModel complaint)
        {
            try
            {
                complaint.ComplaintDate = DateTime.Now;
                bool isCreated = _complaintService.Create(complaint);
                if(isCreated)
                    return JsonConvert.SerializeObject(ApiResponseUtility.CreateSuccessResponse("Complaint Logged" , isCreated));

                return JsonConvert.SerializeObject(ApiResponseUtility.CreateSuccessResponse("Complaint Logged Unsucessful", isCreated));
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ApiResponseUtility.CreateErrorResponse(ex));
            }
        }

        
    }
}
