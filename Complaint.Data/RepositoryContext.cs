using Complaint.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace Complaint.Data
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Complaint.Models.Entities.ComplaintModel> Complaint { get; set; }
    }
}
