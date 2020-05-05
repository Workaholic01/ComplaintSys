using Complaint.Data.RepositoryBase;
using Complaint.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Complaint.Data.ConcreteRepositories.UserRepository
{
    public interface IUserRepository : IRepositoryBase<User>
    {
    }
}
