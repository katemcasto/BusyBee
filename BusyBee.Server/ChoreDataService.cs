using Microsoft.Data.SqlClient;

namespace BusyBee.Server
{
    public class ChoreDataService
    {
        SqlConnection _connection;
        public ChoreDataService() 
        { 
            _connection = new SqlConnection("Server='(localdb)\\MSSQLLocalDB';Database='busybee';User Id='BusyBee';Password='BusyBee';");
        }

        public List<Chore> GetChores()
        {
            List<Chore> chores = new List<Chore>();

            SqlCommand command = new SqlCommand("select * from Chores", _connection);
            _connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Chore chore = new()
                {
                    Name = reader["Name"].ToString(),
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
    }
}
