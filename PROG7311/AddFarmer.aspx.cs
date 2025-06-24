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

		//Inserts a new user, with their email as the primary key, into the database.
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
				ResetInputs();
				//Only fails if either data was somehow invalid (perhaps an error in data entry) or if the user already exists and the database detects a duplicate primary key in the records.
				Email.Attributes.Add("placeholder", "Process Failed.");
			}

		}

		//Hashes a given string of cleartext or normal text.
		public byte[] HashBytes(string cleartext)
		{
			byte[] clearBytes = Encoding.UTF8.GetBytes(cleartext);
			SHA256 hasher = SHA256.Create();
			byte[] hash = hasher.ComputeHash(clearBytes);
			hasher.Clear();
			return hash;
		}

		//Sets inputs to empty.
		public void ResetInputs()
		{
			Email.Value = "";
			Password.Value = "";
			ContactDetails.Value = "";
			Location.Value = "";
		}
	}
}