using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using techneapp.com.domain;

namespace techneapp.com.infrastructure.Interface
{
    public interface IEmployeeInfrastructureService
    {

        public Task<int> PutEmployee(int id, Employee employee);

        public Task<int> PostEmployee(Employee employee);

        public Task<int> DeleteEmployee(int id);
    }
}
