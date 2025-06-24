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

		//Checks if user is an employee and returns a true or false value.
		public bool IsUserEmployee
		{
			get
			{
				return ("Employee").Equals(Session["Role"]);
			}
		}
	}
}