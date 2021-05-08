using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using techneapp.com.application.Interface;
using techneapp.com.domain;
using techneapp.com.infrastructure;
using techneapp.com.infrastructure.Interface;

namespace techneapp.com.application.Service
{
    public class DepartmentApplicationService : IDepartmentApplicationService
    {
        public readonly ITechneAppDbContext _context;
        public readonly IDepartmentInfrastructureService _departmentInfrastructureService;
        public int status = 0;

        public DepartmentApplicationService(ITechneAppDbContext context, IDepartmentInfrastructureService departmentInfrastructureService)
        {
            _context = context;
            _departmentInfrastructureService = departmentInfrastructureService;
        }
        public Task<int> DeleteDepartment(int id)
        {
            return _departmentInfrastructureService.DeleteDepartment(id);
        }

        public async Task<Department> GetDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            return department;
        }

        public async Task<List<domain.Department>> GetDepartments()
        {
            List<domain.Department> department = await _context.Departments.ToListAsync();
            return department;
        }

        public Task<int> PostDepartment(Department department)
        {
            return _departmentInfrastructureService.PostDepartment(department);
        }

        public Task<int> PutDepartment(int id, Department department)
        {
            return _departmentInfrastructureService.PutDepartment(id,department);
        }
    }
}
