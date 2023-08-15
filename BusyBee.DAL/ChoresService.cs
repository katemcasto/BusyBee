using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace BusyBee.DAL
{
    public class ChoresService
    {
        private ILogger<ChoresService> _logger;

        public ChoresService(ILogger<ChoresService> logger) 
        {
            _logger = logger;
        }

        public int AddChore(Chore chore)
        {
            int addedChores = 0;

            try
            {
                string connectionString = GetConnectionString();
                using SqlConnection connection = new(connectionString);
                connection.Open();
                string sql = $"INSERT INTO [dbo].[Chores]\r\nVALUES ('{chore.Description}', '{chore.Complete}', '{chore.CreatedBy}', '{chore.CreatedDate}', '{chore.UpdatedBy}', '{chore.UpdatedDate}')";

                using SqlCommand command = new(sql, connection);
                addedChores = command.ExecuteNonQuery();

                return addedChores;
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);

                return addedChores;
            }
        }

        public List<Chore> GetChores()
        {
            List<Chore> chores = new List<Chore>();

            try
            {
                string connectionString = GetConnectionString();
                using SqlConnection connection = new(connectionString);
                connection.Open();

                string sql = "SELECT *\r\n  FROM BUSYBEE.DBO.CHORES";

                using SqlCommand sqlCommand = new(sql, connection);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Chore chore = new()
                    {
                        Id = (int)reader["ID"],
                        Description = reader["Description"].ToString(),
                        Complete = (bool)reader["Complete"],
                        CreatedBy = reader["CreatedBy"].ToString(),
                        CreatedDate = DateTime.Parse(reader["CreatedDate"].ToString()),
                        UpdatedBy = reader["UpdatedBy"].ToString(),
                        UpdatedDate = DateTime.Parse(reader["UpdatedDate"].ToString())
                    };

                    chores.Add(chore);
                }

                return chores;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
 
                return chores;
            }
        }

        public int UpdateChore(Chore chore)
        {
            int updatedChores = 0;
            try
            {
                string connectionString = GetConnectionString();
                using SqlConnection connection = new(connectionString);
                connection.Open();
                string sql = " UPDATE DBO.Chores \r\n  SET Description = @DESCRIPTION, Complete = @COMPLETE, UpdatedBy = @UPDATEDBY, UpdatedDate = @UPDATEDDATE\r\n  WHERE ID = @ID";

                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@DESCRIPTION", chore.Description);
                command.Parameters.AddWithValue("@COMPLETE", chore.Complete);
                command.Parameters.AddWithValue("@UPDATEDBY", chore.UpdatedBy);
                command.Parameters.AddWithValue("@UPDATEDDATE", chore.UpdatedDate);
                command.Parameters.AddWithValue("@ID", chore.Id);
                updatedChores = command.ExecuteNonQuery();

                return updatedChores;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return updatedChores;
            }
        }

        private string GetConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "(local)";
            builder.UserID = "BusyBee";
            builder.Password = "BusyBee";
            builder.InitialCatalog = "BusyBee";
            builder.TrustServerCertificate = true;

            return builder.ConnectionString;
        }

        public int DeleteChore(Chore chore)
        {
            int deletedChores = 0;

            try
            {
                string connectionString = GetConnectionString();
                using SqlConnection connection = new(connectionString);
                connection.Open();
                string sql = $"DELETE FROM dbo.Chores WHERE ID = @ID";

                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@ID", chore.Id);
                deletedChores = command.ExecuteNonQuery();

                return deletedChores;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return deletedChores;
            }
        }
    }
}