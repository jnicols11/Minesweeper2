using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Minesweeper2.Models;

namespace Minesweeper2.Services.Data
{
    public class SecurityDAO
    {
        string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Minesweeper;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool FindByUser(UserModel user)
        {
            //Now a SQL query is used to search for a record

            //start by assuming that nothing is found
            bool success = false;

            //Provide the query string with a parameter placeholder
            string queryString = "select * from dbo.Users where username = @username and password = @password";

            //create and open the connection in a using block to ensure that all resources will be closed and disposed 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //create the command and parameter objects
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@USERNAME", System.Data.SqlDbType.VarChar, 50).Value = user.Username;
                command.Parameters.Add("@PASSWORD", System.Data.SqlDbType.VarChar, 50).Value = user.Password;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                        success = true;
                    reader.Close();
                }//end try
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }//end catch
            }//end using block statement
            return success;
        }//end FindByUser
    }//end SecurityDAO  
}//end Namespace