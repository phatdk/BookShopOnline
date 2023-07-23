using BookShop.Web.Blazor.Service;
using BookShopBLL.ViewModel;
using Microsoft.AspNetCore.Components;

namespace BookShop.Web.Blazor.Pages.AdminAccountPage
{
	public partial class AdminAccount
	{
		[Inject]
		protected AdminService _adminService { get; set; }
		protected AdminVM _admin { get; set; }
		protected List<AdminVM> _admins { get; set; }

		protected override async Task OnInitializedAsync()
		{

			_admins = await _adminService.GetAsync();
		}

	}
}
