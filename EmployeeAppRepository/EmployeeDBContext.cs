using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using EmployeeAppModels;

namespace EmployeeAppRepository
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions dboptions) : base(dboptions)
        {
        }

        public DbSet<EmployeeRegistration> EmployeeDetails
        {
            get; set;
        }

        public DbSet<Verify> Verification
        {
            get; set;
        }

        public DbSet<Designation> Designations
        {
            get; set;
        }
    }
}