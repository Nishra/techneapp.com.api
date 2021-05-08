using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using techneapp.com.domain;
using techneapp.com.infrastructure.Interface;

namespace techneapp.com.infrastructure.Service
{
    public class EmployeeInfrastructureService : IEmployeeInfrastructureService
    {
        public readonly ITechneAppDbContext _context;
        
        public int status = 0;
        public EmployeeInfrastructureService(ITechneAppDbContext context)
        {
            _context = context;
        }
        public async Task<int> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return status;
            }

            _context.Employees.Remove(employee);
            status = await _context.SaveChangesAsync();

            return status;
        }

        public async Task<int> PostEmployee(Employee employee)
        {
            Employee newEmployee = new Employee()
            {
                EmployeeName = employee.EmployeeName,
                Email = employee.Email,
                DepartmentID = employee.DepartmentID,
                ImageURL = employee.ImageURL,
                ID = employee.ID
            };

            _context.Employees.Add(newEmployee);
            status = await _context.SaveChangesAsync();
            return status;
        }

        public async Task<int> PutEmployee(int id, Employee employee)
        {
            var currentemployee = await _context.Employees.FindAsync(id);
            if (currentemployee == null)
            {
                return status;
            }

            _context.Employees.Update(employee);
            status = await _context.SaveChangesAsync();

            return status;
        }
    }
}
