using Dapper.Domain;
using Dapper.Domain.Persistence;
using Dapper.Repository.Interface;

namespace Dapper.Repository.Repository
{
    public class EmployeeRepository : IEmployee
    {
        private DbContext _dbContext;
        public EmployeeRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddEmployee(employeeMaster employeeMaster)
        {
            int rowAffected = await _dbContext.ExecuteAsync("addemp", new { name = employeeMaster.name, address = employeeMaster.address }, commandType: System.Data.CommandType.StoredProcedure);
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            int rowAffected = await _dbContext.ExecuteAsync("deleteemp", new { id = id }, commandType: System.Data.CommandType.StoredProcedure);
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<List<employeeMaster>> GetAllEmployee()
        {
            var result = await _dbContext.QueryAsync<employeeMaster>("Getallemp", commandType: System.Data.CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<employeeMaster> GetEmployeeById(int id)
        {
            var result = await _dbContext.QuerySingleOrDefaultAsync<employeeMaster>("getempbyid", new { id = id }, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        public async Task<bool> UpdateEmployee(employeeMaster employeeMaster)
        {
            int rowAffected = await _dbContext.ExecuteAsync("updateemp", employeeMaster, commandType: System.Data.CommandType.StoredProcedure);
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }
    }
}
