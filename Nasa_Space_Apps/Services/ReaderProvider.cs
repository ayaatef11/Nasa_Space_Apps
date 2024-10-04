using Microsoft.Data.SqlClient;
using System.Data;

namespace Nasa_Space_Apps.Services
{
    public class ReaderProvider
    {
        //
        void GetAllPlanets()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                // Dapper query to get all elements from the 'Products' table
                string query = "SELECT * FROM Products";

                return db.Query<Product>(query).ToList();
            }
        }
    }
}
