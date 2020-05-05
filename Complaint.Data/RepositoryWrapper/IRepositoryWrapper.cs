using Complaint.Data.ComplaintDataRepository.ConcreteRepositories;
using Complaint.Data.ConcreteRepositories.UserRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Complaint.Data.RepositoryWrapper
{
    public interface IRepositoryWrapper
    {
        IComplaintRepository ComplaintRepository { get; }
        IUserRepository UserRepository { get; }
        int Save();
    }
}
