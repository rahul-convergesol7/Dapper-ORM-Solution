using Dapper.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Repository.Interface
{
    public interface IEmployee
    {
        Task<List<employeeMaster>> GetAllEmployee();
        Task<employeeMaster> GetEmployeeById(int id);
        Task<bool> AddEmployee(employeeMaster employeeMaster);
        Task<bool> DeleteEmployee(int id);
        Task<bool> UpdateEmployee(employeeMaster employeeMaster);

    }
}
