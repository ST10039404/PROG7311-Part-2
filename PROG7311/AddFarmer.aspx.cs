using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROG7311
{
	public partial class AddFarmer : Page
	{
		
		protected void RegisterButton_Click(object sender, EventArgs e)
		{
			Register();
		}

		protected void Register()
		{
			string email = Email.Value;
			string password = Password.Value; 
			string contactInfo = ContactDetails.Value;
			string location = Location.Value;
			try
			{
				string connectionString = ConfigurationManager.ConnectionStrings["Prog7311Database"].ConnectionString;
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					string query = "INSERT INTO Users (UserEmail, PasswordHash, Role, ContactInfo, Location) VALUES (@UserEmail, HASHBYTES('SHA2_256', @Password), @Role, @ContactInfo, @Location))";
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@UserEmail", email);
						command.Parameters.AddWithValue("@Password", password);
						command.Parameters.AddWithValue("@Role", "Farmer");
						command.Parameters.AddWithValue("@ContactInfo", contactInfo);
						command.Parameters.AddWithValue("@Location", location);

						connection.Open();
						command.ExecuteNonQuery();
						connection.Close();
					}
				}
			}
			catch
			{
				clearStuff();
				Email.Attributes.Add("placeholder", "Process Failed.");
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

		public void clearStuff()
		{
			Email.Value = "";
			Password.Value = "";
			ContactDetails.Value = "";
			Location.Value = "";
		}
	}
}