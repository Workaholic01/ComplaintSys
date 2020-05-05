using Complaint.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Complaint.Core.ComplaintCore
{
    public interface IComplaintService
    {
        bool Create(ComplaintModel complaint);
        ComplaintModel FindById(int complaintId);
    }
}
