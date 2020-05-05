using Complaint.Data;
using Complaint.Data.RepositoryWrapper;
using Complaint.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Complaint.Core.Account
{
    public class AccountService : IAccountService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public AccountService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public bool Login(User user)
        {
            User userFound = _repositoryWrapper.UserRepository.FindByCondition(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();
            if (userFound == null)
                return false;

            return true;
        }
    }
}
