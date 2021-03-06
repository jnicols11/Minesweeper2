﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Minesweeper2.Models;

namespace Minesweeper2.Services.Data
{
    public class SecurityDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Minesweeper;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

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
                command.Parameters.Add("@USERNAME", System.Data.SqlDbType.VarChar, 40).Value = user.Username;
                command.Parameters.Add("@PASSWORD", System.Data.SqlDbType.VarChar, 40).Value = user.Password;
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

        internal bool RegisterData(UserModel user)
        {
            //start by assuming that nothing is found
            bool success = false;

            //Provide the query string with a parameter placeholder
            string queryString = "INSERT INTO [dbo].[Users] ([FIRSTNAME], [LASTNAME], [SEX], [AGE], [STATE], [EMAIL], [USERNAME], [PASSWORD]) VALUES ( @firstname, @lastname, @sex, @age, @state, @email, @username, @password)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    cmd.Parameters.AddWithValue(@"firstname", user.FirstName);
                    cmd.Parameters.AddWithValue(@"lastname", user.LastName);
                    cmd.Parameters.AddWithValue(@"sex", user.Sex);
                    cmd.Parameters.AddWithValue(@"age", user.Age);
                    cmd.Parameters.AddWithValue(@"state", user.State);
                    cmd.Parameters.AddWithValue(@"email", user.Email);
                    cmd.Parameters.AddWithValue(@"username", user.Username);
                    cmd.Parameters.AddWithValue(@"password", user.Password);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    success = true;
                    return success;


                }//end using
            }//end using
        }//end RegisterData
    }//end SecurityDAO  
}//end Namespace