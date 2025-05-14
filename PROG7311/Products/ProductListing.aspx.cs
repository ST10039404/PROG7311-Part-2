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
		protected void Page_Load(object sender, EventArgs e)
		{
			showMeMyProducts(sender, e);
		}

		protected void update(List<Product> products)
		{
			pnlProducts.Controls.Clear();
			loadProducts(products);
		}

		protected void SearchbarRun(object sender, EventArgs e)
		{
			var products = new List<Product>();
			if (!SearchBar.Value.IsNullOrWhiteSpace())
			{
				products = GetProducts(SearchBar.Value);
			} else
			{
				products = GetProductsAll();
			}
			update(products);
		}

		protected void showMeMyProducts(object sender,EventArgs e)
		{
			var products = GetProducts(Session["UserEmail"].ToString());
			update(products);
		}

		protected void addANewProduct(object sender, EventArgs e)
		{
			Response.Redirect("~/Products/AddProduct.aspx");
		}

		private List<Product> GetProducts(string UserEmail)
		{
			List<Product> products = new List<Product>();
			string connectionString = ConfigurationManager.ConnectionStrings["Prog7311Database"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string query = "SELECT ProductName, Category, ProductionDate, ProductPrice, COALESCE(ProductImage,(SELECT TOP 1 DefaultImage FROM [DI])) AS ProductImage FROM [Products] WHERE FarmerEmail = @UserEmail";
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@UserEmail", UserEmail);

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

		private void loadProducts(List<Product> products)
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