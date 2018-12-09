using System.Data.SqlClient;

namespace Session1Library
{
    public static class Connection
    {
        public static bool IsConnected()
        {
            try
            {
                using (var session = new Session1Entities())
                {
                    session.Database.Connection.Open();
                    return true;
                }
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
}