using Dapper;
using FastFood.DAL.Interface;
using FastFood.DAL.Models;
using FastFood.Sql_Scripts;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FastFood.DAL.Repositories
{
    // Students ID: 00013836, 00014725, 00014896
    public class IngredientsDapperRepository : IRepository<Ingredients>
    {
        private readonly string? _connStr;

        // Constructor
        public IngredientsDapperRepository(string? connStr)
        {
            _connStr = connStr;
        }

        // Procedures

        private const string Ingredients_GetAll = Sql_Procedure_Scripts.sp_Ingredients_Get_All;
        private const string Ingredients_GetById = Sql_Procedure_Scripts.sp_Ingredients_Get_By_Id;
        private const string Ingredients_Create = Sql_Procedure_Scripts.sp_Ingredients_Insert;
        private const string Ingredients_Update = Sql_Procedure_Scripts.sp_Ingredients_Update;
        private const string Ingredients_Delete = Sql_Procedure_Scripts.sp_Ingredients_Delete;

        //


        // Main functions
        // Create
        public async Task<int> CreateAsync(Ingredients entity)
        {
            using var conn = new SqlConnection(_connStr);
            var parameters = new DynamicParameters();
            parameters.AddDynamicParams(new
            {
                entity.Title,
                entity.Price,
                entity.Amount_in_grams,
                entity.Unit,
                entity.IsForVegan,
                entity.Image
            });
            parameters.Add("ingredient_ID", DbType.Int32, direction: ParameterDirection.Output);

            await conn.ExecuteAsync(Ingredients_Create, parameters, commandType: CommandType.StoredProcedure);
            return parameters.Get<int>("ingredient_ID");
        }

        // Delete
        public async Task DeleteAsync(Ingredients entity)
        {
            using var conn = new SqlConnection(_connStr);
            await conn.ExecuteAsync(Ingredients_Delete, new { Id = entity.ingredient_ID }, commandType: CommandType.StoredProcedure);

        }

        // Get All
        public async Task<IEnumerable<Ingredients>> GetAllAsync()
        {
            using var conn = new SqlConnection(_connStr);
            return await conn.QueryAsync<Ingredients>(Ingredients_GetAll, commandType: CommandType.StoredProcedure);

        }

        // Get By Id
        public async Task<Ingredients> GetByIdAsync(int id)
        {
            using var conn = new SqlConnection(_connStr);
            Ingredients? ingredient = await conn.QueryFirstOrDefaultAsync<Ingredients>(Ingredients_GetById, new { Id = id }, commandType: CommandType.StoredProcedure);
            return ingredient;
        }

        // Update
        public async Task UpdateAsync(Ingredients entity)
        {
            using var conn = new SqlConnection(_connStr);
            await conn.ExecuteAsync(Ingredients_Update, entity, commandType: CommandType.StoredProcedure);

        }
    }
}
