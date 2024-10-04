using Microsoft.Data.SqlClient;
using Nasa_Space_Apps.Models;
using Newtonsoft.Json;

namespace Nasa_Space_Apps.DataAccess
{
    public class Data//store the data in database 
    {
        void Connect()
        {
            string connectionString = "Server=.;Database=Majorbodies;integrated security=true;TrustServerCertificate=true;MultipleActiveResultSets=true";

            // Deserialize the JSON into C# objects
            string jsonFilePath = "C:\\Users\\Aya Atef\\Source\\Repos\\dataset\\majorbodies.json";
            string json = File.ReadAllText(jsonFilePath);
            var celestialBodies = JsonConvert.DeserializeObject<List<CelestialBody>>(json);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (var body in celestialBodies)
                {
                    // Insert into CelestialBodies table
                    string insertBodyQuery = "INSERT INTO CelestialBodies (Id, Name, Symbol, Type, Texture, Radius, Flattening, LightEmitting, FetchElements, Center) " +
                        "VALUES (@Id, @Name, @Symbol, @Type, @Texture, @Radius, @Flattening, @LightEmitting, @FetchElements, @Center)";

                    using (SqlCommand command = new SqlCommand(insertBodyQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", body.Id);
                        command.Parameters.AddWithValue("@Name", body.Name);
                        command.Parameters.AddWithValue("@Symbol", body.Symbol);
                        command.Parameters.AddWithValue("@Type", body.Type);
                        command.Parameters.AddWithValue("@Texture", body.Texture);
                        command.Parameters.AddWithValue("@Radius", body.Radius);
                        command.Parameters.AddWithValue("@Flattening", body.Flattening);
                        command.Parameters.AddWithValue("@LightEmitting", body.LightEmitting);
                        command.Parameters.AddWithValue("@FetchElements", body.FetchElements);
                        command.Parameters.AddWithValue("@Center", body.Center ?? (object)DBNull.Value);
                        command.ExecuteNonQuery();
                    }

                    // Insert into OrbitalElements table if elements exist
                    if (body.Elements != null)
                    {
                        string insertElementsQuery = "INSERT INTO OrbitalElements (CelestialBodyId, ArgOfPeriapsis, Period, AscendingNode, Eccentricity, PeriapsisDistance, TimeOfPeriapsis, SemiMajorAxis, ApoapsisDistance, MeanAnomalyAtEpoch, Epoch, Inclination) " +
                            "VALUES (@CelestialBodyId, @ArgOfPeriapsis, @Period, @AscendingNode, @Eccentricity, @PeriapsisDistance, @TimeOfPeriapsis, @SemiMajorAxis, @ApoapsisDistance, @MeanAnomalyAtEpoch, @Epoch, @Inclination)";

                        using (SqlCommand command = new SqlCommand(insertElementsQuery, connection))
                        {
                            command.Parameters.AddWithValue("@CelestialBodyId", body.Id);
                            command.Parameters.AddWithValue("@ArgOfPeriapsis", body.Elements.ArgOfPeriapsis);
                            command.Parameters.AddWithValue("@Period", body.Elements.Period);
                            command.Parameters.AddWithValue("@AscendingNode", body.Elements.AscendingNode);
                            command.Parameters.AddWithValue("@Eccentricity", body.Elements.Eccentricity);
                            command.Parameters.AddWithValue("@PeriapsisDistance", body.Elements.PeriapsisDistance);
                            command.Parameters.AddWithValue("@TimeOfPeriapsis", body.Elements.TimeOfPeriapsis);
                            command.Parameters.AddWithValue("@SemiMajorAxis", body.Elements.SemiMajorAxis);
                            command.Parameters.AddWithValue("@ApoapsisDistance", body.Elements.ApoapsisDistance);
                            command.Parameters.AddWithValue("@MeanAnomalyAtEpoch", body.Elements.MeanAnomalyAtEpoch);
                            command.Parameters.AddWithValue("@Epoch", body.Elements.Epoch);
                            command.Parameters.AddWithValue("@Inclination", body.Elements.Inclination);
                            command.ExecuteNonQuery();
                        }
                    }

                    // Insert into Rotations table if rotation exists
                    if (body.Rotation != null)
                    {
                        string insertRotationQuery = "INSERT INTO Rotations (CelestialBodyId, MeridianAngle, AscendingNode, Type, Period, Inclination) " +
                            "VALUES (@CelestialBodyId, @MeridianAngle, @AscendingNode, @Type, @Period, @Inclination)";

                        using (SqlCommand command = new SqlCommand(insertRotationQuery, connection))
                        {
                            command.Parameters.AddWithValue("@CelestialBodyId", body.Id);
                            command.Parameters.AddWithValue("@MeridianAngle", body.Rotation.MeridianAngle);
                            command.Parameters.AddWithValue("@AscendingNode", body.Rotation.AscendingNode);
                            command.Parameters.AddWithValue("@Type", body.Rotation.Type);
                            command.Parameters.AddWithValue("@Period", body.Rotation.Period);
                            command.Parameters.AddWithValue("@Inclination", body.Rotation.Inclination);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }

            Console.WriteLine("Data inserted successfully.");
        }
    }
}
