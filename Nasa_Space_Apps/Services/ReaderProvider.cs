using Dapper;
using Microsoft.Data.SqlClient;
using Nasa_Space_Apps.DataAccess;
using Nasa_Space_Apps.Models;
using System.Data;

namespace Nasa_Space_Apps.Services
{
    public class ReaderProvider
    {
        
        //
       public  IEnumerable<CelestialBody> GetAllPlanets()
        {
            using (IDbConnection db = new SqlConnection(Data.connectionString))
            {
                // Dapper query to get all elements from the 'Products' table
                string query = "SELECT * FROM CelestialBodies";

                return db.Query<CelestialBody>(query).ToList();
            }
        }
        

        public CelestialBody SearchByName (string Name)
        {
            using (IDbConnection db = new SqlConnection(Data.connectionString))
            {
                // Dapper query to search by name (using LIKE for partial matches)
                string query = "SELECT * FROM Products WHERE Name LIKE @Name";

                // Parameterized query to prevent SQL injection
                return db.Query<CelestialBody>(query, new { Name = "%" + Name + "%" }).ToList();
            }
            /*Parameterized Query: The @Name in the query is a parameter placeholder. You pass the actual value via an
             * anonymous object (new { Name = "%" + name + "%" }).
             The % in the query is used with LIKE to allow partial matching. For example, searching for "Pro" would return
            "Product", "Proactive", etc.
               Query Method: db.Query<Product>() executes the query and maps the result to a collection of Product objects.*/
        }

        public IEnumerable< CelestialBody> FilterByType(string Type)
        {
            using (IDbConnection db = new SqlConnection(Data.connectionString))
            {
                // Dapper query to search by name (using LIKE for partial matches)
                string query = "SELECT * FROM Products WHERE Type LIKE @Type";

                // Parameterized query to prevent SQL injection
                return db.Query<CelestialBody>(query, new { Name = "%" + Type + "%" }).ToList();
            }
        
        }
    }
}
