using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
	public class Book
	{
		public int Id { get; set; }

		public string Title { get; set; }
		[Required]
		public string Description { get; set; }

		public string Price { get; set; }
		public int CategoryID { get; set; }
		public Category Category { get; set; }
		public int Quantity { get; set; }
	}
}