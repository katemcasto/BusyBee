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
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = "(local)";
                builder.UserID = "BusyBee";
                builder.Password = "BusyBee";
                builder.InitialCatalog = "BusyBee";
                builder.TrustServerCertificate = true;

                using SqlConnection connection = new(builder.ConnectionString);
                connection.Open();

                string sql = $"INSERT INTO [dbo].[Chores]\r\nVALUES ('{chore.Description}', '{chore.Complete}', '{chore.CreatedBy}', '{chore.CreatedDate}', '{chore.UpdatedBy}', '{chore.UpdatedDate}')";

                using SqlCommand command = new(sql, connection);
                addedChores = command.ExecuteNonQuery();

                return addedChores;
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.ToString());

                return addedChores;
            }
        }

        public List<Chore> GetChores()
        {
            List<Chore> chores = new List<Chore>();

            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = "(local)";
                builder.UserID = "BusyBee";
                builder.Password = "BusyBee";
                builder.InitialCatalog = "BusyBee";
                builder.TrustServerCertificate = true;

                using SqlConnection connection = new(builder.ConnectionString);
                connection.Open();

                string sql = "SELECT *\r\n  FROM BUSYBEE.DBO.CHORES";

                using SqlCommand sqlCommand = new(sql, connection);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Chore chore = new()
                    {
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
                _logger.LogError(ex.ToString());
 
                return chores;
            }
        }
    }
}