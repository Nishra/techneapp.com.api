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
    public class EmployeeApplicationService : IEmployeeApplicationService
    {
        public readonly ITechneAppDbContext _context;
        public readonly IEmployeeInfrastructureService _employeeInfrastructureService;
        public int status = 0;
        public EmployeeApplicationService(ITechneAppDbContext context, IEmployeeInfrastructureService employeeInfrastructureService)
        {
            _context = context;
            _employeeInfrastructureService = employeeInfrastructureService;
        }
        public Task<int> DeleteEmployee(int id)
        {
            return _employeeInfrastructureService.DeleteEmployee(id);
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return employee;
        }

        public async Task<List<domain.Employee>> GetEmployees()
        {
            List<domain.Employee> employee = await _context.Employees.ToListAsync();
            return employee;
        }

        public Task<int> PostEmployee(Employee employee)
        {
            return _employeeInfrastructureService.PostEmployee(employee);
        }

        public Task<int> PutEmployee(int id, Employee employee)
        {
            return _employeeInfrastructureService.PutEmployee(id, employee);
        }
    }
}
