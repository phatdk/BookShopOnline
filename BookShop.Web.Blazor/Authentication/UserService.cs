
namespace BookShop.Web.Blazor.Authentication
{
	public class UserService
	{
		private List<UserAccount> _accounts;
        public UserService()
        {
            _accounts = new List<UserAccount>()
            {
                new UserAccount{ Name = "Help deck", Email = "Helpdeck", Password ="1", Role = "Admin"},
                new UserAccount{ Name = "Customer", Email = "test", Password ="1", Role = "User"}
            };
        }
        public UserAccount? GetAccount(string email)
        {
            var account = _accounts.FirstOrDefault(a => a.Email == email);
    //        if(account == null)
    //        {
    //            string apiUrl = $"https://localhost:7033/api/Admin/get?address={email}"+$"&s=1";
    //            var httpClient = new HttpClient();
				//var newAcc = new UserAccount();
    //            var admin = _adminService.GetByIdAsync(null, email, 1);
    //            if (admin != null)
    //            {
    //                newAcc.Id = admin.Result.Id;
    //                newAcc.Name = "Admin";
    //                newAcc.Email = email;
    //                newAcc.Password = admin.Result.Password;
    //                newAcc.Role = "Admin";
    //                return newAcc;
    //            }
    //            var cus = _customerService.GetByIdAsync(null, email, 1);
    //            if (cus.Result != null)
    //            {
    //                newAcc.Id = cus.Result.Id;
    //                newAcc.Name = cus.Result.Name;
    //                newAcc.Email = email;
    //                newAcc.Password = cus.Result.Password;
    //                newAcc.Role = "User";
    //                return newAcc;
    //            }
			//}
            return account;
        }
    }
}
