﻿using System;
using System.Collections
    .Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Minesweeper2.Models;
using Minesweeper2.Services.Utility;

namespace Minesweeper2.Services.Data
{
    public class SecurityDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Minesweeper;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private static MinesweeperLogger logger = MinesweeperLogger.GetInstance();

        public bool FindByUser(UserModel user)
        {
            MinesweeperLogger.GetInstance().Info("Entering SecurityDAO.FindByUser()");
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
                    user.encrypt(user.Password);
                    command.Parameters.Add("@PASSWORD", System.Data.SqlDbType.VarChar, 200).Value = user.Password;
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
                MinesweeperLogger.GetInstance().Info("Exiting SecurityDAO.FindByUser()");
                return success;
            }//end using
        }//end FindByUser

        internal bool RegisterData(UserModel user)
        {
            MinesweeperLogger.GetInstance().Info("Entering SecurityDAO.REgisterData()");
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
                    user.encrypt(user.Password);
                    cmd.Parameters.AddWithValue(@"password", user.Password);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    success = true;
                    MinesweeperLogger.GetInstance().Info("Exiting SecurityDAO.REgisterData()");
                    return success;


                }//end using
            }//end using
        }//end RegisterData

        public bool inputStats(StatsModel sm)
        {
            MinesweeperLogger.GetInstance().Info("Entering SecurityDAO.ImputStats()");
            bool success = false;

            string queryString = "INSERT INTO [dbo].[Stats] ([USERNAME], [SCORE], [TIME]) VALUES ( @username, @score, @time)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using(SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    cmd.Parameters.AddWithValue(@"username", sm.Username);
                    cmd.Parameters.AddWithValue(@"score", sm.Score);
                    cmd.Parameters.AddWithValue(@"time", sm.Time);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    success = true;
                    MinesweeperLogger.GetInstance().Info("Exiting SecurityDAO.ImputStats()");
                    return success;
                }//end nested using
            }//end using
        }//end inputStats

        public List<StatsModel> getAllStats()
        {
            MinesweeperLogger.GetInstance().Info("Entering SecurityDAO.getAllStats()");
            List<StatsModel> theStats = new List<StatsModel>();
            string queryString = "SELECT * FROM [dbo].[Stats]";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            StatsModel stat = new StatsModel(reader.GetDouble(3), reader.GetDouble(2), reader.GetString(3));
                            theStats.Add(stat);
                        }//end while
                        connection.Close();
                    }//end try
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }//end while loop

                    return theStats;
                }//end nested using
            }//end using

        }//end getAllStats
    }//end SecurityDAO  
}//end Namespace