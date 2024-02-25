using EduHomeTask.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHomeTask.Data
{
    public class EventDao
    {
        public void Insert(Event eventItem, List<int> speakerIds)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.LOCAL))
            {
                string query = "INSERT INTO Events (Name,Descrp,Adress,StartDate,StartTime,EndTime)" +
                    " VALUES (@Name,@Description,@Adress,@StartDate,@StartTime,@EndTime)";

                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", eventItem.Name);
                    cmd.Parameters.AddWithValue("@Description", eventItem.Description);
                    cmd.Parameters.AddWithValue("@Adress", eventItem.Address);
                    cmd.Parameters.AddWithValue("@StartDate", eventItem.StartDate);
                    cmd.Parameters.AddWithValue("@StartTime", eventItem.StartTime);
                    cmd.Parameters.AddWithValue("@EndTime", eventItem.EndTime);

                    cmd.ExecuteNonQuery();
                }
            }
            AddEventSpeakers(eventItem.Id, speakerIds);
        }

        public void AddEventSpeakers(int eventId, List<int> speakerIds)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.LOCAL))
            {
                connection.Open();
                string query = "INSERT INTO EventSpeaker (EventId, SpeakerId) " +
                    "VALUES (@EventId, @SpeakerId)";
                foreach (int speakerId in speakerIds)
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EventId", eventId);
                        command.Parameters.AddWithValue("@SpeakerId", speakerId);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public Event GetById(int id)
        {
            Event eventItem = null;
            using (SqlConnection connection = new SqlConnection(ConnectionString.LOCAL))
            {
                connection.Open();
                string query = "SELECT * FROM Events WHERE id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                using (SqlDataReader sqlData = command.ExecuteReader())
                {
                    if (!sqlData.HasRows) return null;
                    while (sqlData.Read())
                    {
                        eventItem = new Event()
                        {
                            Id = sqlData.GetInt32(sqlData.GetOrdinal("Id")),
                            Name = sqlData.GetString(sqlData.GetOrdinal("Name")),
                            Description = sqlData.GetString(sqlData.GetOrdinal("Descrp")),
                            StartDate = sqlData.GetDateTime(sqlData.GetOrdinal("StartDate")),
                            StartTime = sqlData.GetTimeSpan(sqlData.GetOrdinal("StartTime")),
                            EndTime = sqlData.GetTimeSpan(sqlData.GetOrdinal("EndTime")),
                            Address = sqlData.GetString(sqlData.GetOrdinal("Adress"))
                        };

                    }
                }
            }
            return eventItem;
        }

        public List<Event> GetAllEvents()
        {
            List<Event> events = new List<Event>();
            using (SqlConnection connection = new SqlConnection(ConnectionString.LOCAL))
            {
                connection.Open();
                string query = "SELECT * FROM Events";
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader sqlData = command.ExecuteReader())
                {
                    while (sqlData.Read())
                    {
                        Event event1 = new Event()
                        {
                            Id = sqlData.GetInt32(sqlData.GetOrdinal("Id")),
                            Name = sqlData.GetString(sqlData.GetOrdinal("Name")),
                            Description = sqlData.GetString(sqlData.GetOrdinal("Descrp")),
                            StartDate = sqlData.GetDateTime(sqlData.GetOrdinal("StartDate")),
                            StartTime = sqlData.GetTimeSpan(sqlData.GetOrdinal("StartTime")),
                            EndTime = sqlData.GetTimeSpan(sqlData.GetOrdinal("EndTime")),
                            Address = sqlData.GetString(sqlData.GetOrdinal("Adress"))
                        };
                        events.Add(event1);
                    }
                }
            }

            return events;
        }

        public int AddSpeaker(int eventId, int speakerId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.LOCAL))
            {
                connection.Open();
                string query = "INSERT INTO EventSpeaker (EventId, SpeakerId)" +
                    " VALUES (@EventId, @SpeakerId)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EventId", eventId);
                    command.Parameters.AddWithValue("@SpeakerId", speakerId);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public int RemoveSpeaker(int eventId, int speakerId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.LOCAL))
            {
                connection.Open();
                string query = "DELETE FROM EventSpeaker WHERE" +
                    " EventId = @EventId and SpeakerId = @SpeakerId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EventId", eventId);
                    command.Parameters.AddWithValue("@SpeakerId", speakerId);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public int Delete(int eventId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.LOCAL))
            {
                connection.Open();
                string query = "DELETE FROM Events WHERE  id = @EventId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EventId", eventId);
                    return command.ExecuteNonQuery();
                }
            }


        }
    }
}
