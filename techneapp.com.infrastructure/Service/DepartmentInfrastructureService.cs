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
        public Task<int> DeleteDepartment(int id)
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
