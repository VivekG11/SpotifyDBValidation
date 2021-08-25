using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Data;
using System.Data.SqlClient;


namespace WebDriver
{
    [TestClass]
    public class UnitTest1
    {
        public static string connectionString = @"Server = (localdb)\MSSQLLocalDB; Initial Catalog = LoginDetails";
        SqlConnection connection = new SqlConnection(connectionString);
        [TestMethod]
        public void TestMethod1()
        {
            string query = @"select Top(1) [email] from Details";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader;

            reader = command.ExecuteReader();

            

        }

        public void setup()
        {
           
        }
    }
}
