using PROG7311.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROG7311
{
	public partial class AddProduct : Page
	{
		//Selects whether to add product if valid or to reset inputs if invalid.
		protected void AddNewProductButton_Click(object sender, EventArgs e)
		{
			if (Page.IsValid) //Checks if inputs are valid.
			{
				AddNewProduct();
			}
			else
			{
				ResetInputs();
			}
		}

		//Runs INSERT Sql Command using valid parameters from the input form.
		protected void AddNewProduct()
		{
			string productName = ProductName.Text;
			string category = Category.Text;
			DateTime productionDate = DateTime.Parse(ProductionDate.Text);
			int productPrice = int.Parse(ProductPrice.Text);
			byte[] productImageBytes = null;

			if (ProductImage.HasFile)
			{
				using (var binaryReader = new BinaryReader(ProductImage.PostedFile.InputStream))
				{
					productImageBytes = binaryReader.ReadBytes(ProductImage.PostedFile.ContentLength);
				}
			}

			string connectionString = ConfigurationManager.ConnectionStrings["Prog7311Database"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string query = "INSERT INTO Products (FarmerEmail, ProductName, Category, ProductionDate, ProductPrice, ProductImage) VALUES (@FarmerEmail, @ProductName, @Category, @ProductionDate, @ProductPrice, @ProductImage)";
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@FarmerEmail", Session["UserEmail"]);
					command.Parameters.AddWithValue("@ProductName", productName);
					command.Parameters.AddWithValue("@Category", category);
					command.Parameters.AddWithValue("@ProductionDate", productionDate);
					command.Parameters.AddWithValue("@ProductPrice", productPrice);
					command.Parameters.AddWithValue("@ProductImage", productImageBytes);

					connection.Open();
					command.ExecuteNonQuery();
					connection.Close();
				}
			}
			//Redirects back to list of products so that user instantly sees the product they entered be reflected.
			Response.Redirect("~/Products/ProductListing.aspx");
		}

		//Sets input fields to empty.
		protected void ResetInputs()
		{
			ProductName.Text = null;
			Category.Text = null;
			ProductionDate.Text = null;
			ProductPrice.Text = null;
			ProductImage.Attributes.Clear();
		}

	}
}