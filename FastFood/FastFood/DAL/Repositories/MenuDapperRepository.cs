using Dapper;
using FastFood.DAL.Interface;
using FastFood.DAL.Models;
using FastFood.Sql_Scripts;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FastFood.DAL.Repositories
{
    // Students ID: 00013836, 00014725, 00014896
    public class MenuDapperRepository : IRepository<Menu>
    {
        private readonly string? _connStr;

        // Constructor
        public MenuDapperRepository(string? connStr)
        {
            _connStr = connStr;
        }

        // Procedures

        private const string Menu_GetAll = Sql_Procedure_Scripts.sp_Menu_Get_All;
        private const string Menu_GetById = Sql_Procedure_Scripts.sp_Menu_Get_By_Id;
        private const string Menu_Create = Sql_Procedure_Scripts.sp_Menu_Insert;
        private const string Menu_Update = Sql_Procedure_Scripts.sp_Menu_Update;
        private const string Menu_Delete = Sql_Procedure_Scripts.sp_Menu_Delete;

        //

        // Main functions
        // Create
        public async Task<int> CreateAsync(Menu entity)
        {
            using var conn = new SqlConnection(_connStr);
            var parameters = new DynamicParameters();
            parameters.AddDynamicParams(new
            {
                entity.meal_title,
                entity.price,
                entity.size,
                entity.TimeToPrepare,
                entity.Image,
                entity.IsForVegan,
                entity.CreatedDate
            });
            parameters.Add("menu_ID", DbType.Int32, direction: ParameterDirection.Output);

            await conn.ExecuteAsync(Menu_Create, parameters, commandType: CommandType.StoredProcedure);
            return parameters.Get<int>("menu_ID");
        }

        // Delete
        public async Task DeleteAsync(Menu entity)
        {
            using var conn = new SqlConnection(_connStr);
            await conn.ExecuteAsync(Menu_Delete, new { Id = entity.meal_ID }, commandType: CommandType.StoredProcedure);

        }

        // Get All
        public async Task<IEnumerable<Menu>> GetAllAsync()
        {
            using var conn = new SqlConnection(_connStr);
            return await conn.QueryAsync<Menu>(Menu_GetAll, commandType: CommandType.StoredProcedure);

        }

        // Get By Id
        public async Task<Menu> GetByIdAsync(int id)
        {
            using var conn = new SqlConnection(_connStr);
            Menu? menu = await conn.QueryFirstOrDefaultAsync<Menu>(Menu_GetById, new { Id = id }, commandType: CommandType.StoredProcedure);
            return menu;
        }

        // Update
        public async Task UpdateAsync(Menu entity)
        {
            using var conn = new SqlConnection(_connStr);
            await conn.ExecuteAsync(Menu_Update, entity, commandType: CommandType.StoredProcedure);

        }
    }
}
