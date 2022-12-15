using System.Configuration;

namespace Serviex.Test.Repository
{
    public class ConnectionRepository
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Serviex_testDB"].ToString();
        }
    }
}
