using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using techneapp.com.domain;

namespace techneapp.com.infrastructure.Interface
{
    public interface IDepartmentInfrastructureService
    {

        public Task<int> PutDepartment(int id, Department department);

        public Task<int> PostDepartment(Department department);

        public Task<int> DeleteDepartment(int id);
    }
}
