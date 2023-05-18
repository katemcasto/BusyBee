using Microsoft.Data.SqlClient;

namespace BusyBee.DAL
{
    public class ChoresService
    {
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

                string sql = "INSERT INTO [dbo].[Chores]\r\nVALUES ('', 0, '', SYSDATETIME(), '', SYSDATETIME())";

                using SqlCommand command = new(sql, connection);
                addedChores = command.ExecuteNonQuery();

                return addedChores;
            }
            catch (Exception ex) 
            {
                return addedChores;
            }
        }
    }
}