using BookShop.Web.Blazor.Service;
using BookShopBLL.ViewModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;

namespace BookShop.Web.Blazor.Pages.Admin
{
	public partial class AuthorManager
	{
		[Inject]
		protected AuthorService authorService { get; set; }
		protected AuthorVM authorVM { get; set; }
		protected List<AuthorVM> authorVMs { get; set; }

		protected bool isHide = true;
		protected bool isChecked = true;
		protected override async Task OnInitializedAsync()
		{
			await LoadData();
		}
		protected async Task LoadData()
		{
			authorVMs = await authorService.GetAsync(null);
		}
		protected async Task IndexUp(Guid id)
		{
			authorVM = await authorService.GetByIdAsync(id);
			if (authorVM.Index == null)
			{
				authorVM.Index = 0;
				await authorService.UpdateAsync(authorVM);
			}
			if(authorVM.Index < 99)
			{
				authorVM.Index++;
				await authorService.UpdateAsync(authorVM);
			}
			await LoadData();
		}
		protected async Task IndexDown(Guid id)
		{
			authorVM = await authorService.GetByIdAsync(id);
			if (authorVM.Index == null)
			{
				authorVM.Index = 99;
				await authorService.UpdateAsync(authorVM);
			}
			if (authorVM.Index > 0)
			{
				authorVM.Index--;
				await authorService.UpdateAsync(authorVM);
			}
			await LoadData();
		}
		protected async Task UpdateIndex(Guid id, object value)
		{
			authorVM = await authorService.GetByIdAsync(id);
			if (value.Equals("")) value = null;
			authorVM.Index = int.Parse(value.ToString());
			var result = await authorService.UpdateAsync(authorVM);
		}
		protected async Task View(Guid id)
		{
			isHide = false;
			authorVM = await authorService.GetByIdAsync(id);
			if (authorVM.Status == 1) isChecked = true; else isChecked = false;
		}
		protected async Task Hide()
		{
			isHide = true;
			authorVM = null;
		}
		protected async Task UpdateAuthor()
		{
			if (isChecked) { authorVM.Status = 1; } else { authorVM.Status = 0; }
			var result = await authorService.UpdateAsync(authorVM);

			if (result)
			{
				await LoadData();
				isHide = true;
			}
		}
		protected async Task DisableAuthor()
		{
			authorVM.Status = 0;
			var result = await authorService.UpdateAsync(authorVM);
			if (result)
			{
				await LoadData();
				isHide = true;
			}
		}
	}
}
