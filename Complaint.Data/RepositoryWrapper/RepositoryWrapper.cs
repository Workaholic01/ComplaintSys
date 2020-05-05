using Complaint.Data.ComplaintDataRepository.ConcreteRepositories;
using Complaint.Data.ConcreteRepositories.UserRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Complaint.Data.RepositoryWrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        public IUserRepository _userRepository;
        public IComplaintRepository _complaintRepository;
        private RepositoryContext _repositoryContext;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IComplaintRepository ComplaintRepository
        {
            get {
                if (_complaintRepository == null)
                    _complaintRepository = new ComplaintRepository(_repositoryContext);

                return _complaintRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_repositoryContext);

                return _userRepository;
            }
        }

        public int Save()
        {
            return _repositoryContext.SaveChanges();
        }
    }
}
