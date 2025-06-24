using PROG7311.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROG7311
{
	public partial class _Default : Page
	{
		//Authenticates user if valid then sends them to the home page.
		protected void LoginButton_Click(object sender, EventArgs e)
		{
			bool successfulLogin = Login();

			if (successfulLogin == true)
			{
				Response.Redirect("~/Home.aspx", true);
			}
			else 
			{
				Email.Value = "YOU FAILED";
			}

		}

		//Returns true if email and password is valid or false if anything else.
		protected bool Login()
		{
			byte[] passwordHashFromDatabase = null;
			string loggedInUserRole = null;
			string connectionString = ConfigurationManager.ConnectionStrings["Prog7311Database"].ConnectionString;

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string query = "SELECT UserEmail, PasswordHash, Role FROM Users WHERE UserEmail = @UserEmail";
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@UserEmail", Request.Form["Email"]);

					connection.Open();
					SqlDataReader reader = command.ExecuteReader();

					if (reader.HasRows)
					{
						reader.Read();
						passwordHashFromDatabase = (byte[])reader["PasswordHash"];
						loggedInUserRole = (string)reader["Role"];
					}
					else
					{
						return false;
					}
					connection.Close();
				}
			}

			//Checks if the hash on the database is equal to the hashed version of the entered password.
			if (passwordHashFromDatabase.SequenceEqual(HashBytes(Request.Form["Password"])))
			{
				Session["UserEmail"] = Request.Form["Email"];
				Session["Role"] = loggedInUserRole;
				return true;
			}
			else
			{
				return false;
			}
		}

		//Hashes a given string of cleartext or normal text.
		protected byte[] HashBytes(string cleartext)
		{
			byte[] clearBytes = Encoding.UTF8.GetBytes(cleartext);
			SHA256 hasher = SHA256.Create();
			byte[] hash = hasher.ComputeHash(clearBytes);
			hasher.Clear();
			return hash;
		}

		//Sets inputs to empty.
		protected void ResetInputs()
		{
			Email.Value = "";
			Password.Value = "";
		}
	}
}