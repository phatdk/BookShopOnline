using BookShop.Web.Blazor.Service;
using BookShopBLL.ViewModel;
using BookShopDAL.Entity;
using Microsoft.AspNetCore.Components;

namespace BookShop.Web.Blazor.Pages.Admin
{
	public partial class GenreManager
	{
		[Inject]
		protected GenreService genreService { get; set; }
		protected GenreVM genreVM { get; set; }
		protected List<GenreVM> genreVMs { get; set;}

		protected bool isHide = true;
		protected bool isChecked = true;

		protected override async Task OnInitializedAsync()
		{
			await LoadData();
		}

		protected async Task LoadData()
		{
			genreVMs = await genreService.GetAsync(null);
		}
		protected async Task IndexUp(Guid id)
		{
			genreVM = await genreService.GetByIdAsync(id);
			if (genreVM.Index == null)
			{
				genreVM.Index = 0;
				await genreService.UpdateAsync(genreVM);
			}
			if (genreVM.Index < 99)
			{
				genreVM.Index++;
				await genreService.UpdateAsync(genreVM);
			}
			await LoadData();
		}
		protected async Task IndexDown(Guid id)
		{
			genreVM = await genreService.GetByIdAsync(id);
			if (genreVM.Index == null)
			{
				genreVM.Index = 99;
				await genreService.UpdateAsync(genreVM);
			}
			if (genreVM.Index > 0)
			{
				genreVM.Index--;
				await genreService.UpdateAsync(genreVM);
			}
			await LoadData();
		}
		protected async Task UpdateIndex(Guid id, object value)
		{
			genreVM = await genreService.GetByIdAsync(id);
			if (value.Equals("")) value = null;
			genreVM.Index = int.Parse(value.ToString());
			var result = await genreService.UpdateAsync(genreVM);
		}
		protected async Task View(Guid id)
		{
			isHide = false;
			genreVM = await genreService.GetByIdAsync(id);
			if (genreVM.Status == 1) isChecked = true; else isChecked = false;
		}
		protected async Task Hide()
		{
			isHide = true;
			genreVM = null;
		}
		protected async Task UpdateAuthor()
		{
			if (isChecked) { genreVM.Status = 1; } else { genreVM.Status = 0; }
			var result = await genreService.UpdateAsync(genreVM);

			if (result)
			{
				await LoadData();
				isHide = true;
			}
		}
		protected async Task DisableAuthor()
		{
			genreVM.Status = 0;
			var result = await genreService.UpdateAsync(genreVM);
			if (result)
			{
				await LoadData();
				isHide = true;
			}
		}
	}
}
