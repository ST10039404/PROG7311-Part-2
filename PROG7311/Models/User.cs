using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PROG7311.Models
{
	public class User
	{
		[Key]
		public int UserID { get; set; }

		[Required]
		[StringLength(50)]
		public string Username { get; set; }

		[Required]
		[StringLength(256)]
		public string PasswordHash { get; set; }

		[Required]
		[StringLength(10)]
		public string Role { get; set; }

		[StringLength(100)]
		public string ContactInfo { get; set; }

		[Required]
		[StringLength(100)]
		public string Location { get; set; }

		// Navigation property for related Products
		public ICollection<Product> Products { get; set; }
	}
}