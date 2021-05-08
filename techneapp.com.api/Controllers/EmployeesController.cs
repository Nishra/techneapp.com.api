using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using techneapp.com.application.Interface;
using techneapp.com.domain;
using techneapp.com.infrastructure;

namespace techneapp.com.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly TechneAppDbContext _context;
        private readonly IEmployeeApplicationService _employeeApplicationService;

        public EmployeesController(TechneAppDbContext context, IEmployeeApplicationService employeeApplicationService)
        {
            _context = context;
            _employeeApplicationService = employeeApplicationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _employeeApplicationService.GetEmployee(id);

            if (employee == null)
            {
                return StatusCode(404, "Invalid employee ID, employee Details not Found");
            }

            return employee;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            await _employeeApplicationService.PutEmployee(id, employee);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return StatusCode(404, "Invalid Employee ID, Insert a Valid Employee ID");
                }
                else
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return StatusCode(200, "Employee Details Updated Successfully");
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            await _employeeApplicationService.PostEmployee(employee);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeeExists(employee.ID))
                {
                    return StatusCode(409, "Duplication of employee ID, Change the employee ID and Try Again");
                }
                else
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return StatusCode(200, "Employee Details Addedd Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            await _employeeApplicationService.DeleteEmployee(id);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeeExists(id))
                {
                    return StatusCode(409, "Delete Process Failed, Try Again");
                }
                else
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return StatusCode(200, "Employee Details Deleted Successfully");
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.ID == id);
        }
    }
}
