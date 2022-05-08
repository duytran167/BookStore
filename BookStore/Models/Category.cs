using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
	public class Category
	{
		public int Id { get; set; }
		[Required]
		public string CategoryName { get; set; }
	}
}