using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ParcelSolutionsHomePrj.Models;
using System.Data;

namespace ParcelSolutionsHomePrj.Data
{
    public class DataRepository : IDataRepository
    {
        private readonly string _connectionString;
        private readonly string _storedProcedure;

        public DataRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _storedProcedure = configuration["StoredProcedure"];
        }
        public List<CustomData> GetDataResult()
        {
            var result = new List<CustomData>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(_storedProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var row = new CustomData();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row.Data.Add(reader.GetName(i), reader[i]?.ToString());
                            }
                            result.Add(row);
                        }
                    }
                }
            }
            return result;
        }
    }

}
