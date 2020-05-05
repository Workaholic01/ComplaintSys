using Complaint.Data.RepositoryBase;
using Complaint.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Complaint.Data.ConcreteRepositories.UserRepository
{
    public class UserRepository : RepositoryBase<User> , IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
                
        }
    }
}
