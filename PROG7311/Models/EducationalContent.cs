using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PROG7311.Models
{
	public class EducationalContent
	{
		[Key]
		public int EducationalContentID { get; set; }

		[ForeignKey("User")]
		public int UserID { get; set; }

		[Required]
		[StringLength(50)]
		public string EducationalContentShortSummary { get; set; }

		[Required]
		[StringLength(700)]
		public string EducationalContentFullDetails { get; set; }

		public byte[] EducationalContentImage { get; set; }

		// Navigation property for related User
		public User User { get; set; }
	}
}