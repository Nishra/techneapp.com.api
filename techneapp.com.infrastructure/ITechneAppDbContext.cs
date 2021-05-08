using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using techneapp.com.domain;

namespace techneapp.com.infrastructure
{
    public interface ITechneAppDbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        Task<int> SaveChangesAsync();
    }
}
