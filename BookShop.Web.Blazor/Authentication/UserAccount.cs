namespace BookShop.Web.Blazor.Authentication
{
	public class UserAccount
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Role { get; set; }
	}
}
