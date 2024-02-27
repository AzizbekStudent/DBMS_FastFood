using Dapper;
using FastFood.DAL.Interface;
using FastFood.DAL.Models;
using FastFood.Sql_Scripts;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FastFood.DAL.Repositories
{
    // Students ID: 00013836, 00014725, 00014896
    public class Menu_Ingredients_DapperRepository : IRepository<Menu_Ingredients>
    {
        private readonly string? _connStr;

        // Constructor
        public Menu_Ingredients_DapperRepository(string? connStr)
        {
            _connStr = connStr;
        }

        // Procedures

        private const string M_I_GetAll = Sql_Procedure_Scripts.sp_Menu_Ingredients_Get_All;
        private const string M_I_GetById = Sql_Procedure_Scripts.sp_Menu_Ingredients_Get_By_Id;
        private const string M_I_Create = Sql_Procedure_Scripts.sp_Menu_Ingredients_Insert;
        private const string M_I_Update = Sql_Procedure_Scripts.sp_Menu_Ingredients_Update;
        private const string M_I_Delete = Sql_Procedure_Scripts.sp_Menu_Ingredients_Delete;

        //


        // Main functions
        // Create
        public async Task<int> CreateAsync(Menu_Ingredients entity)
        {
            using var conn = new SqlConnection(_connStr);
            await conn.ExecuteAsync(M_I_Create, new { mealID = entity.meal_ID, ingredientID = entity.ingredient_ID }, commandType: CommandType.StoredProcedure);
            return (int)entity.meal_ID;
        }

        // Delete
        public async Task DeleteAsync(Menu_Ingredients entity)
        {
            using var conn = new SqlConnection(_connStr);
            await conn.ExecuteAsync(M_I_Delete, new { mealID = entity.meal_ID, ingredientID = entity.ingredient_ID }, commandType: CommandType.StoredProcedure);

        }

        // Get All
        public async Task<IEnumerable<Menu_Ingredients>> GetAllAsync()
        {
            using var conn = new SqlConnection(_connStr);
            return await conn.QueryAsync<Menu_Ingredients>(M_I_GetAll, commandType: CommandType.StoredProcedure);

        }

        // Get By Id
        public async Task<Menu_Ingredients> GetByIdAsync(int id)
        {
            using var conn = new SqlConnection(_connStr);
            Menu_Ingredients? meal = await conn.QueryFirstOrDefaultAsync<Menu_Ingredients>(M_I_GetById, new { Id = id }, commandType: CommandType.StoredProcedure);
            return meal;
        }

        // Update
        public async Task UpdateAsync(Menu_Ingredients entity)
        {
            using var conn = new SqlConnection(_connStr);
            await conn.ExecuteAsync(M_I_Update,
                new { mealID = entity.meal_ID, ingredientID = entity.ingredient_ID},
                commandType: CommandType.StoredProcedure);
        }
    }
}
