using Dapper;
using FastFood.DAL.Interface;
using FastFood.DAL.Models;
using FastFood.Sql_Scripts;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using System.Data;


namespace FastFood.DAL.Repositories
{
    public class EmployeeDapperRepository : IRepository<Employee>
    {
        private readonly string? _connStr;

        // Constructor
        public EmployeeDapperRepository(string? connStr)
        {
            _connStr = connStr;
        }

        // Procedures

        private const string Employee_GetAll = Sql_Procedure_Scripts.sp_Employee_Get_All;
        private const string Employee_Create = Sql_Procedure_Scripts.sp_Employee_Insert;
        private const string Employee_Update = Sql_Procedure_Scripts.sp_Employee_Update;
        private const string Employee_GetByID = Sql_Procedure_Scripts.sp_Employee_Get_By_Id;
        private const string Employee_Delete = Sql_Procedure_Scripts.sp_Employee_Delete;

        //

        // Main Functions
        // Get All
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            using var conn = new SqlConnection(_connStr);
            return await conn.QueryAsync<Employee>(Employee_GetAll, commandType: CommandType.StoredProcedure);
        }

        // Get By ID
        public async Task<Employee> GetByIdAsync(int id)
        {
            using var conn = new SqlConnection(_connStr);
            Employee? employee = await conn.QueryFirstOrDefaultAsync<Employee>(Employee_GetByID, new { Id = id }, commandType: CommandType.StoredProcedure);
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

            await conn.ExecuteAsync(Employee_Create, parameters, commandType: CommandType.StoredProcedure);
            return parameters.Get<int>("employee_ID");
        }

        // Update
        public async Task UpdateAsync(Employee entity)
        {
            using var conn = new SqlConnection(_connStr);
            await conn.ExecuteAsync(Employee_Update, entity, commandType: CommandType.StoredProcedure);

        }

        // Delete
        public async Task DeleteAsync(Employee entity)
        {
            using var conn = new SqlConnection(_connStr);
            await conn.ExecuteAsync(Employee_Delete, new { Id = entity.employee_ID }, commandType: CommandType.StoredProcedure);

        }







    }
}
