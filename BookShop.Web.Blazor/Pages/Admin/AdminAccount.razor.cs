using BookShop.Web.Blazor.Service;
using BookShopBLL.ViewModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BookShop.Web.Blazor.Pages.Admin
{
	public partial class AdminAccount
	{
		[Inject]
		protected AdminService _adminService { get; set; }
		protected AdminVM _admin { get; set; }
		protected List<AdminVM> _admins { get; set; }

		protected bool isChecked = true;
		protected string notification;

		protected bool isAddButton = false;
		protected bool isUpdateButton = true;
		protected bool isDeleteButton = true;

		protected bool isProStatus = true;

		protected override async Task OnInitializedAsync()
		{
			_admins = await _adminService.GetAsync();
			_admin = new AdminVM();
		}
		protected async Task ClearForm()
		{
			isAddButton = false;
			isUpdateButton = true;
			isDeleteButton = true;
			isProStatus = true;
			_admin = new AdminVM()
			{
				Email = " ",
				Password = " ",
			};
			//navManager.NavigateTo(navManager.Uri, forceLoad: true);
		}

		// chuc nang
		protected async Task ViewAccount(Guid id)
		{
			isProStatus = false;
			isAddButton = true;
			isUpdateButton = false;
			isDeleteButton = false;
			_admin = await _adminService.GetByIdAsync(id, null, null);
			if (_admin.Status == 1) isChecked = true;
			else isChecked = false;
		}

		protected async Task AddAccount()
		{
			var result = await _adminService.AddAsync(_admin);
			if (result)
			{
				_admins = await _adminService.GetAsync();
				await ClearForm();
			}
			else notification = "Create false";
		}
		protected async Task UpdateAccount()
		{
			if (isChecked) { _admin.Status = 1; } else { _admin.Status = 0; }
			var result = await _adminService.UpdateAsync(_admin);
			if (result)
			{
				_admins = await _adminService.GetAsync();
				await ClearForm();
			}
		}
		protected async Task DisalbeAccout()
		{
			bool confirm = await js.InvokeAsync<bool>("confirm", "Bạn chắc chắn muốn vô hiệu hóa tài khoản?");
			if (confirm)
			{
				_admin.Status = 0;
				var result = await _adminService.UpdateAsync(_admin);
			}
		}
		protected async Task DeleteAccount()
		{
			bool confirm = await js.InvokeAsync<bool>("confirm", "Bạn chắc chắn muốn xóa tài khoản?");
			if (confirm)
			{
				var result = await _adminService.DeleteAsync(_admin.Id);
				if (result)
				{
					_admins = await _adminService.GetAsync();
					await ClearForm();
				}
			}
		}
	}
}
