using Complaint.Data;
using Complaint.Data.ComplaintDataRepository.ConcreteRepositories;
using Complaint.Data.RepositoryWrapper;
using Complaint.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Complaint.Core.ComplaintCore
{
    public class ComplaintService : IComplaintService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public ComplaintService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public bool Create(ComplaintModel complaint)
        {
            try
            {
                _repositoryWrapper.ComplaintRepository.Create(complaint);
                _repositoryWrapper.Save();

                if (complaint.Id > 0)
                    return true;

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ComplaintModel FindById(int complaintId)
        {
            ComplaintModel complaint = null;
            try
            {
                complaint = _repositoryWrapper.ComplaintRepository.FindByCondition(x=>x.Id == complaintId).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }

            return complaint;
        }
    }
}
