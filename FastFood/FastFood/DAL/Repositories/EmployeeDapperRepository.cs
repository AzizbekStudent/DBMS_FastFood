using Dapper;
using FastFood.DAL.Interface;
using FastFood.DAL.Models;
using FastFood.Sql_Scripts;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using System.Data;


namespace FastFood.DAL.Repositories
{
    // Students ID: 00013836, 00014725, 00014896
    public class EmployeeDapperRepository : IRepository<Employee>
    {
        private readonly string? _connStr;

        // Constructor
        public EmployeeDapperRepository(string? connStr)
        {
            _connStr = connStr;
        }

        // Procedures

        private const string udp_GetAllEmployee = Sql_Procedure_Scripts.udp_GetAllEmployee;
        private const string p_Employee_Insert = Sql_Procedure_Scripts.p_Employee_Insert;
        private const string p_Employee_Update = Sql_Procedure_Scripts.p_Employee_Update;
        private const string p_Employee_Get_ByID = Sql_Procedure_Scripts.p_Employee_Get_ByID;
        private const string p_Employee_Delete = Sql_Procedure_Scripts.p_Employee_Delete;

        //

        // Main Functions
        // Get All
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            using var conn = new SqlConnection(_connStr);
            return await conn.QueryAsync<Employee>("udp_GetAllEmployee", commandType: CommandType.StoredProcedure);
        }

        // Get By ID
        public async Task<Employee> GetByIdAsync(int id)
        {
            using var conn = new SqlConnection(_connStr);
            Employee? employee = await conn.QueryFirstOrDefaultAsync<Employee>("p_Employee_Get_ByID", new { Id = id }, commandType: CommandType.StoredProcedure);
            return employee;
        }

        // Create
        public async Task<int> CreateAsync(Employee entity)
        {
            using var conn = new SqlConnection(_connStr);
            var parameters = new DynamicParameters();
            parameters.AddDynamicParams(new
            {
                entity.FName,
                entity.LName,
                entity.Telephone,
                entity.Job,
                entity.Age,
                entity.Salary,
                entity.HireDate,
                entity.Image,
                entity.FullTime
            });
            parameters.Add("employee_ID", DbType.Int32, direction: ParameterDirection.Output);

            await conn.ExecuteAsync("p_Employee_Insert", parameters, commandType: CommandType.StoredProcedure);
            return parameters.Get<int>("employee_ID");
        }

        // Update
        public async Task UpdateAsync(Employee entity)
        {
            using var conn = new SqlConnection(_connStr);
            await conn.ExecuteAsync("p_Employee_Update", entity, commandType: CommandType.StoredProcedure);

        }

        // Delete
        public async Task DeleteAsync(Employee entity)
        {
            using var conn = new SqlConnection(_connStr);
            await conn.ExecuteAsync("p_Employee_Delete", new { Id = entity.employee_ID }, commandType: CommandType.StoredProcedure);

        }







    }
}
