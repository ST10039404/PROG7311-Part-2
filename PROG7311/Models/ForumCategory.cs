using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PROG7311.Models
{
	public class ForumCategory
	{
		[Key]
		public int ForumCategoryID { get; set; }

		[Required]
		public int ForumCategoryName { get; set; }  // Assuming it is an integer

		[Required]
		[StringLength(255)]  // Assuming a max length for ForumCategoryDetails
		public string ForumCategoryDetails { get; set; }

		// Navigation property for related ForumMessages
		public ICollection<ForumMessage> ForumMessages { get; set; }
	}
}