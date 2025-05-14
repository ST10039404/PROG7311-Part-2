using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PROG7311.Models
{
	public class ForumMessage
	{
		[Key]
		public int ForumMessageID { get; set; }

		[ForeignKey("ForumCategory")]
		public int ForumCategoryID { get; set; }

		[Required]
		[StringLength(100)]
		public string AuthorName { get; set; }

		[Required]
		public string ForumMessageDetails { get; set; }

		[Required]
		public DateTime ForumMessageDate { get; set; }

		// Navigation property for related ForumCategory
		public ForumCategory ForumCategory { get; set; }
	}
}