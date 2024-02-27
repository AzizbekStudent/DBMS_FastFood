using Dapper;
using FastFood.DAL.Interface;
using FastFood.DAL.Models;
using FastFood.Sql_Scripts;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FastFood.DAL.Repositories
{
    // Students ID: 00013836, 00014725, 00014896
    public class OrdersDapperRepository : IRepository<Orders>
    {
        private readonly string? _connStr;

        // Constructor
        public OrdersDapperRepository(string? connStr)
        {
            _connStr = connStr;
        }

        // Procedures

        private const string Order_GetAll = Sql_Procedure_Scripts.sp_Order_Get_All;
        private const string Order_GetById = Sql_Procedure_Scripts.sp_Order_Get_By_Id;
        private const string Order_Create = Sql_Procedure_Scripts.sp_Order_Insert;
        private const string Order_Update = Sql_Procedure_Scripts.sp_Order_Update;
        private const string Order_Delete = Sql_Procedure_Scripts.sp_Order_Delete;

        //

        // Main Functions
        // Create
        public async Task<int> CreateAsync(Orders entity)
        {
            using var conn = new SqlConnection(_connStr);
            var parameters = new DynamicParameters();
            parameters.AddDynamicParams(new
            {
                entity.OrderTime,
                entity.DeliveryTime,
                entity.PaymentStatus,
                entity.Meal_ID,
                entity.Amount,
                entity.TotalCost,
                entity.Prepared_By
            });
            parameters.Add("order_ID", DbType.Int32, direction: ParameterDirection.Output);

            await conn.ExecuteAsync(Order_Create, parameters, commandType: CommandType.StoredProcedure);
            return parameters.Get<int>("order_ID");
        }

        // Delete
        public async Task DeleteAsync(Orders entity)
        {
            using var conn = new SqlConnection(_connStr);
            await conn.ExecuteAsync(Order_Delete, new { Id = entity.order_ID }, commandType: CommandType.StoredProcedure);

        }

        // Get All
        public async Task<IEnumerable<Orders>> GetAllAsync()
        {
            using var conn = new SqlConnection(_connStr);
            return await conn.QueryAsync<Orders>(Order_GetAll, commandType: CommandType.StoredProcedure);

        }

        // Get By ID
        public async Task<Orders> GetByIdAsync(int id)
        {
            using var conn = new SqlConnection(_connStr);
            Orders? order = await conn.QueryFirstOrDefaultAsync<Orders>(Order_GetById, new { Id = id }, commandType: CommandType.StoredProcedure);
            return order;
        }

        // Update
        public async Task UpdateAsync(Orders entity)
        {
            using var conn = new SqlConnection(_connStr);
            await conn.ExecuteAsync(Order_Update, entity, commandType: CommandType.StoredProcedure);

        }
    }
}
