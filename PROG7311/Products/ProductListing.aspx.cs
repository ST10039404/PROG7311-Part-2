using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using PROG7311.Models;

namespace PROG7311
{
	public partial class ProductListing : Page
	{
		//Automatically shows products for logged in user first
		protected void Page_Load(object sender, EventArgs e)
		{
			ShowLoggedInUserProducts(sender, e);
		}

		//Clears and then loads products onto products panel
		protected void UpdateProductsPanel(List<Product> products)
		{
			pnlProducts.Controls.Clear();
			LoadProducts(products);
		}

		//Takes input from the search bar and runs GetProducts or GetProductsAll.
		protected void SearchbarRun(object sender, EventArgs e)
		{
			var products = new List<Product>();

			if (!SearchBar.Value.IsNullOrWhiteSpace())
			{
				products = GetProducts(SearchBar.Value);
			}
			else
			{
				products = GetProductsAll();
			}

			UpdateProductsPanel(products);
		}

		//Shows logged in user's products by using a session variable.
		protected void ShowLoggedInUserProducts(object sender,EventArgs e)
		{
			var products = GetProducts(Session["UserEmail"].ToString());

			UpdateProductsPanel(products);
		}

		//Switches to the add product page.
		protected void AddANewProduct(object sender, EventArgs e)
		{
			Response.Redirect("~/Products/AddProduct.aspx");
		}

		//Gets products for an entered email.
		private List<Product> GetProducts(string userEmail)
		{
			List<Product> products = new List<Product>();
			string connectionString = ConfigurationManager.ConnectionStrings["Prog7311Database"].ConnectionString;

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string query = "SELECT ProductName, Category, ProductionDate, ProductPrice, COALESCE(ProductImage,(SELECT TOP 1 DefaultImage FROM [DI])) AS ProductImage FROM [Products] WHERE FarmerEmail = @UserEmail";
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@UserEmail", userEmail);

					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							Product product = new Product
							{
								ProductName = reader["ProductName"].ToString(),
								Category = reader["Category"].ToString(),
								ProductionDate = Convert.ToDateTime(reader["ProductionDate"]),
								ProductPrice = Convert.ToInt32(reader["ProductPrice"]),
								ProductImage = reader["ProductImage"] as byte[]
							};
							products.Add(product);
						}
						connection.Close();
					}
					
				}
			}
			return products;
		}

		//Gets all products available on the database.
		private List<Product> GetProductsAll()
		{
			List<Product> products = new List<Product>();
			string connectionString = ConfigurationManager.ConnectionStrings["Prog7311Database"].ConnectionString;

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string query = "SELECT ProductName, Category, ProductionDate, ProductPrice, COALESCE(p.ProductImage, di.DefaultImage) AS ProductImage FROM Products AS p LEFT JOIN DI as di ON 1=1";
				using (SqlCommand command = new SqlCommand(query, connection))
				{

					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							Product product = new Product
							{
								ProductName = reader["ProductName"].ToString(),
								Category = reader["Category"].ToString(),
								ProductionDate = Convert.ToDateTime(reader["ProductionDate"]),
								ProductPrice = Convert.ToInt32(reader["ProductPrice"]),
								ProductImage = reader["ProductImage"] as byte[]
							};
							products.Add(product);
						}
						connection.Close();
					}

				}
			}
			return products;
		}

		//Assigns products from a given list of products to a list item.
		private void LoadProducts(List<Product> products)
		{
			foreach (var product in products)
			{
				var productItem = (UserControls.ProductListingItem)LoadControl("~/UserControls/ProductListingItem.ascx");
				productItem.ProductName = product.ProductName;
				productItem.Category = product.Category;
				productItem.ProductionDate = product.ProductionDate.ToString();
				productItem.ProductPrice = product.ProductPrice.ToString("C");
				productItem.ProductImage = product.ProductImage;

				pnlProducts.Controls.Add(productItem);
			}
		}
	}
}