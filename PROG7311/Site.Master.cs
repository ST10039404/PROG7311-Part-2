using PROG7311.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROG7311
{
	public partial class SiteMaster : MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}
		public bool IsUserEmployee
		{
			get
			{
				// Replace this with your actual condition checking logic
				return ("Employee").Equals(Session["Role"]);
			}
		}
	}
}