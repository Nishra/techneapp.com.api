using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using techneapp.com.domain;
using techneapp.com.infrastructure.Interface;

namespace techneapp.com.infrastructure.Service
{
    public class DepartmentInfrastructureService : IDepartmentInfrastructureService
    {
        public readonly ITechneAppDbContext _context;

        public int status = 0;
        public DepartmentInfrastructureService(ITechneAppDbContext context)
        {
            _context = context;
        }
        public async Task<int> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return status;
            }

            _context.Departments.Remove(department);
            status = await _context.SaveChangesAsync();

            return status;
        }

        public async Task<int> PostDepartment(Department department)
        {
            Department newDepartment = new Department()
            {
                ID = department.ID,
                DepartmentName = department.DepartmentName
            };

            _context.Departments.Add(newDepartment);
            status = await _context.SaveChangesAsync();
            return status;
        }

        public async Task<int> PutDepartment(int id, Department department)
        {
            var currentDepartment = await _context.Departments.FindAsync(id);
            if (currentDepartment == null)
            {
                return status;
            }

            _context.Departments.Update(department);
            status = await _context.SaveChangesAsync();

            return status;
        }
    }
}
