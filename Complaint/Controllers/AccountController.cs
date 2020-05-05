using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Complaint.Data;
using Complaint.Models.Entities;
using Complaint.Core.Account;
using Newtonsoft.Json;
using Complaint.Services.Utilities;

namespace Complaint.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

      

        [HttpPost]
        [Route("/Account/Login")]
        public string Login(User user)
        {
            try
            {
                bool isLoggedIn = _accountService.Login(user);
                if(isLoggedIn)
                    return JsonConvert.SerializeObject(ApiResponseUtility.CreateSuccessResponse("Login Sucessful", isLoggedIn));

                return JsonConvert.SerializeObject(ApiResponseUtility.CreateSuccessResponse("Username or Password Incorrect" , isLoggedIn));
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ApiResponseUtility.CreateErrorResponse(ex));
            }
        }

       
    }
}
