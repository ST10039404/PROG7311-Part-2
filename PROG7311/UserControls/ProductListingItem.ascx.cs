using PROG7311.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROG7311.UserControls
{
	public partial class ProductListingItem : UserControl
	{
		public string ProductName 
		{
			get { return Product_NameDetail.Text;  }
			set { Product_NameDetail.Text = value; }
		}
		public string Category 
		{
			get { return Product_CategoryDetail.Text;  }
			set { Product_CategoryDetail.Text = value; }
		}
		public string ProductionDate
		{
			get { return Product_DateDetail.Text.ToString();  }
			set { Product_CategoryDetail.Text = value.ToString(); }
		}
		public string ProductPrice
		{
			get { return Product_PriceDetail.Text;  }
			set { Product_CategoryDetail.Text = value.ToString(); }
		}
		public byte[] ProductImage
		{
			set
			{
				if (value != null)
				{
					string base64String = Convert.ToBase64String(value, 0, value.Length);
					Product_ImageDetails.ImageUrl = "data:image/png;base64," + base64String;
				}
			}
		} 
	}
}