using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using techneapp.com.application.Interface;
using techneapp.com.domain;

namespace techneapp.com.application.Service
{
    public class DepartmentApplicationService : IDepartmentApplicationService
    {
        public Task<int> DeleteDepartment(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Department> GetDepartment(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Department> GetDepartments()
        {
            throw new NotImplementedException();
        }

        public Task<int> PostDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public Task<int> PutDepartment(int id, Department department)
        {
            throw new NotImplementedException();
        }
    }
}
