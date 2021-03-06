using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using techneapp.com.domain;

namespace techneapp.com.infrastructure
{
    public class TechneAppDbContext : DbContext, ITechneAppDbContext
    {
        public TechneAppDbContext(DbContextOptions<TechneAppDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
