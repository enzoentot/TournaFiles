﻿using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using TournaManagementModels;

namespace TournaManagementData
{
    public class SqlDbData
    {
        private string _connectionString = "Data Source=DESKTOP-TC94IK2\\SQLEXPRESS01;Initial Catalog=Enzotourna;Integrated Security=True;";
        private readonly SmtpClient _smtpClient;

        public SqlDbData()
        {
            _smtpClient = new SmtpClient("smtp.mailtrap.io", 587) 
            {
                Credentials = new NetworkCredential("ddbb0751c0d634", "95bbd360d01848"), 
                EnableSsl = true
            };
        }

        public List<User> GetUsers()
        {
            var users = new List<User>();
            string selectStatement = "SELECT ign, mlbbid, status FROM users";

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            using (SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection))
            {
                sqlConnection.Open();
                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            ign = reader["ign"].ToString(),
                            mlbbid = reader["mlbbid"].ToString(),
                            status = reader["status"].ToString()
                        });
                    }
                }
            }

            return users;
        }

        public int AddUser(string ign, string mlbbid, string status)
        {
            string insertStatement = "INSERT INTO users (ign, mlbbid, status) VALUES (@ign, @mlbbid, @status)";
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            using (SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection))
            {
                insertCommand.Parameters.AddWithValue("@ign", ign);
                insertCommand.Parameters.AddWithValue("@mlbbid", mlbbid);
                insertCommand.Parameters.AddWithValue("@status", status);
                sqlConnection.Open();
                int rowsAffected = insertCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    SendEmail("New User Added", $"User added: {ign}");
                }

                return rowsAffected;
            }
        }

        public int UpdateUser(string ign, string mlbbid, string status)
        {
            string updateStatement = "UPDATE users SET mlbbid = @mlbbid, status = @status WHERE ign = @ign";
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            using (SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection))
            {
                updateCommand.Parameters.AddWithValue("@mlbbid", mlbbid);
                updateCommand.Parameters.AddWithValue("@status", status);
                updateCommand.Parameters.AddWithValue("@ign", ign);
                sqlConnection.Open();
                int rowsAffected = updateCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    SendEmail("User Updated", $"User updated: {ign}");
                }

                return rowsAffected;
            }
        }

        public int DeleteUser(string ign)
        {
            string deleteStatement = "DELETE FROM users WHERE ign = @ign";
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            using (SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection))
            {
                deleteCommand.Parameters.AddWithValue("@ign", ign);
                sqlConnection.Open();
                return deleteCommand.ExecuteNonQuery();
            }
        }

        private void SendEmail(string subject, string body)
        {
            var mailMessage = new MailMessage("enzomendoza8teen@gmail.com", "your-mailtrap-inbox-address@mailtrap.io") 
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            _smtpClient.Send(mailMessage);
        }
    }
}

