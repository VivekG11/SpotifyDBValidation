using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Data;
using System.Data.SqlClient;


namespace SpotifyDBValidation
{
    [TestClass]
    public class UnitTest1
    {
        public static string connectionString = @"Server = (localdb)\MSSQLLocalDB; Initial Catalog = Spotify";
        SqlConnection connection = new SqlConnection(connectionString);

        [TestMethod]
        public void TestMethod1()
        {
            connection.Open();
            string query = @"insert into userTable(userid,userName,playlistId,email) values (5,'Kumar',13,'kumar24@gmail.com')";
            SqlCommand insertCommand = new SqlCommand(query, connection);
            int res = insertCommand.ExecuteNonQuery();
            Assert.AreEqual(1, res);
           
        }
    }
}
