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
		protected void LoginButton_Click(object sender, EventArgs e)
		{
			bool succ = Login();
			if (succ == true)
			{
				Response.Redirect("~/Home.aspx", true);
			}
			else 
			{
				Email.Value = "YOU FAILED";
			}

		}

		protected bool Login()
		{
			byte[] passwordHashDatabase = null;
			string myRole = null;
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
						passwordHashDatabase = (byte[])reader["PasswordHash"];
						myRole = (string)reader["Role"];
					}
					else
					{
						return false;
					}
					connection.Close();
				}
			}

			if (passwordHashDatabase.SequenceEqual(HashBytes(Request.Form["Password"])))
			{
				Session["UserEmail"] = Request.Form["Email"];
				Session["Role"] = myRole;
				return true;
			}
			else
			{
				return false;
			}
		}

		public byte[] HashBytes(string cleartext)
		{
			byte[] clearBytes = Encoding.UTF8.GetBytes(cleartext);
			SHA256 hasher = SHA256.Create();
			byte[] hash = hasher.ComputeHash(clearBytes);
			hasher.Clear();
			return hash;
		}
	}
}