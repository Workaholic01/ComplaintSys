using Complaint.Data.RepositoryBase;
using Complaint.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Complaint.Data.ComplaintDataRepository.ConcreteRepositories
{
    public interface IComplaintRepository : IRepositoryBase<ComplaintModel>
    {
    }
}
