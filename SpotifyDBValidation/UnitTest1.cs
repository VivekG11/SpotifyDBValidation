using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Data;
using System.Data.SqlClient;



namespace SpotifyDBValidation
{
    [TestClass]
    public class UnitTest1
    {
        //establishing connection
        public static string connectionString = @"Server = (localdb)\MSSQLLocalDB; Initial Catalog = Spotify";
        SqlConnection connection = new SqlConnection(connectionString);


        //method to insert a row into database
        [TestMethod]
        public void insertIntoDatabase()
        {
            //openinig connection 
            connection.Open();
            //query to insert a row into database
            string insertQuery = @"insert into userTable (userid, userName, playlistId, email) values (@0,@1,@2,@3)";
            SqlCommand command = new SqlCommand(insertQuery, connection);

            command.Parameters.Add(new SqlParameter("0", 6));
            command.Parameters.Add(new SqlParameter("1", "Vinay"));
            command.Parameters.Add(new SqlParameter("2", 21));
            command.Parameters.Add(new SqlParameter("3", "vinay2@gmail.com"));
            

           
            int res = command.ExecuteNonQuery();
            


            Assert.AreEqual(1, res);
            connection.Close();


        }

        //Method to insert multiple rows into a table
        [TestMethod]
        public void insertMultpileRows()
        {
            try
            {
                //query to insert multiple rowns
                string query = @"insert into userTable(userid,userName,playlistId,email) values (7,'Meghana',11,'meghana23@gmail.com')," +
                                "(8,'Hari',13,'hari21@gmail.com'),(9,'Anil',11,'anil10@gmail.com')";
                SqlCommand insertCommand = new SqlCommand(query, connection);


                connection.Open();
                int res = insertCommand.ExecuteNonQuery();
                connection.Close();


                Assert.AreEqual(3, res);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        public void DeleteRecord()
        {
            try
            {
                //Query to delete a record
                string sqlQuery = @"Delete from userTable where userid= 9";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                int res = command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        [TestMethod]
        public void UpdateRecord()
        {
            try
            {
                //Query to Update a record
                string sqlQuery = @"update userTable set playlistId = 21 where userid= 5";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                int res = command.ExecuteNonQuery();
                connection.Close();

                if (res != 0)
                {
                    System.Console.WriteLine("Executed Successfully....");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        [TestMethod]
        public void RetrieveFRomDatabase()
        {
            try
            {
                string query = @"select * from userTable";

                connection.Open();
                SqlCommand selectCommand = new SqlCommand(query, connection);
                SqlDataReader reader;

                reader = selectCommand.ExecuteReader();

                Assert.AreEqual(-1, reader.RecordsAffected);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
