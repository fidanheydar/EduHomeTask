using EduHomeTask.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHomeTask.Data
{
    public class SpeakerDao
    {
        public int Insert(Speaker speaker)
        {
            var result = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionString.LOCAL))
            {
                connection.Open();

                string query = "INSERT INTO Speakers (FullName, Position, Company, ImageUrl) " +
                               "VALUES (@FullName, @Position, @Company, @ImageUrl)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FullName", speaker.FullName);
                    command.Parameters.AddWithValue("@Position", speaker.Position);
                    command.Parameters.AddWithValue("@Company", speaker.Company);
                    command.Parameters.AddWithValue("@ImageUrl", speaker.ImageUrl);

                    result = command.ExecuteNonQuery();
                }
            }

            return result;
        }


        public void Update(Speaker speaker)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.LOCAL))
            {
                connection.Open();

                string query = "UPDATE Speakers " +
                                     "SET FullName = @FullName, Position = @Position, Company = @Company, ImageUrl = @ImageUrl " +
                                     "WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", speaker.Id);
                    command.Parameters.AddWithValue("@FullName", speaker.FullName);
                    command.Parameters.AddWithValue("@Position", speaker.Position);
                    command.Parameters.AddWithValue("@Company", speaker.Company);
                    command.Parameters.AddWithValue("@ImageUrl", speaker.ImageUrl);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Speaker GetById(int id)
        {
            Speaker speaker = null;
            using (SqlConnection connection = new SqlConnection(ConnectionString.LOCAL))
            {
                connection.Open();

                string query = "SELECT Id, FullName, Position, Company, ImageUrl FROM Speakers WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows) return null;

                        while (reader.Read())
                        {
                            speaker = new Speaker
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                FullName = reader.GetString(reader.GetOrdinal("FullName")),
                                Position = reader.GetString(reader.GetOrdinal("Position")),
                                Company = reader.GetString(reader.GetOrdinal("Company")),
                                ImageUrl = reader.GetString(reader.GetOrdinal("ImageUrl"))
                            };
                        }
                    }
                }
            }

            return speaker;
        }

        public List<Speaker> GetAll()
        {
            List<Speaker> speakers = new List<Speaker>();

            using (SqlConnection connection = new SqlConnection(ConnectionString.LOCAL))
            {
                connection.Open();

                string query = "SELECT Id, FullName, Position, Company, ImageUrl FROM Speakers";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            speakers.Add(new Speaker
                            {
                                Id = (int)reader["Id"],
                                FullName = reader["FullName"].ToString(),
                                Position = reader["Position"].ToString(),
                                Company = reader["Company"].ToString(),
                                ImageUrl = reader["ImageUrl"].ToString()
                            });
                        }
                    }
                }
            }

            return speakers;
        }


        public int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.LOCAL))
            {
                string query = "DELETE FROM Speakers WHERE Id = @Id";

                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    return command.ExecuteNonQuery();
                }
            }
        }


    }
}

