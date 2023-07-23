using System.ComponentModel.DataAnnotations;

namespace BookShopDAL.Entity
{
	public class Book
	{
		public Guid Id { get; set; }
		public string? ISBN { get; set; }
		[Required, MaxLength(100)]
		public string Title { get; set; }
		[Required]
		[Range(1000, 1000000000, ErrorMessage = "Price must be greater than 1000")]
		public int Price { get; set; }
		[Required]
		[Range(1000, 1000000000, ErrorMessage = "Import price must be greater than 1000")]
		public int ImportPrice { get; set; }
		[Required, MaxLength(50)]
		public string Reader { get; set; }
		[Required]
		[Range(0, 1000000000, ErrorMessage = "Quantity must be greater than 0")]
		public int Quantity { get; set; }
		[Required]
		[Range(0, 1000000000, ErrorMessage = "Pages must be greater than 0")]
		public int Pages { get; set; }
		[Required]
		public DateTime PublicationDate { get; set; }
		[Required]
		public string PageSize { get; set; }
		[Required]
		public string Cover { get; set; }
		[Range(0, 1000000000, ErrorMessage = "Weight must be greater than 0")]
		public float Weight { get; set; }
		[MaxLength(256)]
		public string? Description { get; set; }
		public DateTime CreatedDate { get; set;}
		[Required]
		public int Status { get; set; }
		// FK
		public Guid Id_Publisher { get; set; }
		public Guid Id_Genre { get; set; }
		public Guid? Id_Brand { get; set; }
		public Guid? Id_Collection { get; set; }
		public virtual Publisher publisher { get; set; }
		public virtual Genre genre { get; set; }
		public virtual Brand? brand { get; set; }
		public virtual Collection_Book? collection_Book { get; set; }

		// reference
		public virtual List<Image> images { get; set; }
		public virtual List<Book_Author> book_Authors { get; set; }
		public virtual List<Book_Promotion> book_Promotions { get; set; }
		public virtual List<Evaluate> evaluates { get; set; }
		public virtual List<Comment> comments { get; set; }
		public virtual List<WishList> wishLists { get; set; }
		public virtual List<Cart> carts { get; set; }
		public virtual List<Order_Book> order_Books { get; set; }
	}
}
