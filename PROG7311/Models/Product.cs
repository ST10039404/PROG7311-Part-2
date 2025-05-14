using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PROG7311.Models
{
	public class Product
	{
		[Key]
		public int ProductID { get; set; }

		[ForeignKey("User")]
		public int FarmerID { get; set; }

		[Required]
		[StringLength(100)]
		public string ProductName { get; set; }

		[Required]
		[StringLength(50)]
		public string Category { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateTime ProductionDate { get; set; }

		[Required]
		public int ProductPrice { get; set; }

		public byte[] ProductImage { get; set; }

		// Navigation property for related User (Farmer)
		public User User { get; set; }

	}
}