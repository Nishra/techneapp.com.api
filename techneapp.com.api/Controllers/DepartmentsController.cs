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
    public class DepartmentsController : ControllerBase
    {
        private readonly TechneAppDbContext _context;

        private readonly IDepartmentApplicationService _departmentApplicationService;

        public DepartmentsController(TechneAppDbContext context, IDepartmentApplicationService departmentApplicationService)
        {
            _context = context;
            _departmentApplicationService  = departmentApplicationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {

            var department = await _departmentApplicationService.GetDepartment(id);

            if (department == null)
            {
                return StatusCode(404, "Invalid department ID, department Details not Found");
            }

            return department;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, Department department)
        {
            await _departmentApplicationService.PutDepartment(id, department);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
                {
                    return StatusCode(404, "Invalid Department ID, Insert a Valid Department ID");
                }
                else
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return StatusCode(200, "Department Details Updated Successfully");
        }

        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department department)
        {
            await _departmentApplicationService.PostDepartment(department);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DepartmentExists(department.ID))
                {
                    return StatusCode(409, "Duplication of department ID, Change the department ID and Try Again");
                }
                else
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return StatusCode(200, "Department Details Addedd Successfully");
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Department>> DeleteDepartment(int id)
        {
            await _departmentApplicationService.DeleteDepartment(id);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DepartmentExists(id))
                {
                    return StatusCode(409, "Delete Process Failed, Try Again");
                }
                else
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return StatusCode(200, "Department Details Deleted Successfully");
        }

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.ID == id);
        }
    }
}
