using Complaint.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Complaint.Core.Account
{
    public interface IAccountService
    {

        bool Login(User user);
    }
}
