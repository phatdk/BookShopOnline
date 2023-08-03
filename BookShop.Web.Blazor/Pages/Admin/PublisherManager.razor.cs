using BookShop.Web.Blazor.Service;
using BookShopBLL.ViewModel;
using Microsoft.AspNetCore.Components;

namespace BookShop.Web.Blazor.Pages.Admin
{
	public partial class PublisherManager
	{
		[Inject]
		protected PublisherService publisherService { get; set; }
		protected PublisherVM publisherVM { get; set; }
		protected List<PublisherVM> publisherVMs { get; set; }

		protected bool isHide = true;
		protected bool isChecked = true;

		protected override async Task OnInitializedAsync()
		{
			await LoadData();
		}

		protected async Task LoadData()
		{
			publisherVMs = await publisherService.GetAsync(null);
		}
		protected async Task IndexUp(Guid id)
		{
			publisherVM = await publisherService.GetByIdAsync(id);
			if (publisherVM.Index == null)
			{
				publisherVM.Index = 0;
				await publisherService.UpdateAsync(publisherVM);
			}
			if (publisherVM.Index < 99)
			{
				publisherVM.Index++;
				await publisherService.UpdateAsync(publisherVM);
			}
			await LoadData();
		}
		protected async Task IndexDown(Guid id)
		{
			publisherVM = await publisherService.GetByIdAsync(id);
			if (publisherVM.Index == null)
			{
				publisherVM.Index = 99;
				await publisherService.UpdateAsync(publisherVM);
			}
			if (publisherVM.Index > 0)
			{
				publisherVM.Index--;
				await publisherService.UpdateAsync(publisherVM);
			}
			await LoadData();
		}
		protected async Task UpdateIndex(Guid id, object value)
		{
			publisherVM = await publisherService.GetByIdAsync(id);
			if (value.Equals("")) value = null;
			publisherVM.Index = int.Parse(value.ToString());
			var result = await publisherService.UpdateAsync(publisherVM);
		}
		protected async Task View(Guid id)
		{
			isHide = false;
			publisherVM = await publisherService.GetByIdAsync(id);
			if (publisherVM.Status == 1) isChecked = true; else isChecked = false;
		}
		protected async Task Hide()
		{
			isHide = true;
			publisherVM = null;
		}
		protected async Task UpdateAuthor()
		{
			if (isChecked) { publisherVM.Status = 1; } else { publisherVM.Status = 0; }
			var result = await publisherService.UpdateAsync(publisherVM);

			if (result)
			{
				await LoadData();
				isHide = true;
			}
		}
		protected async Task DisableAuthor()
		{
			publisherVM.Status = 0;
			var result = await publisherService.UpdateAsync(publisherVM);
			if (result)
			{
				await LoadData();
				isHide = true;
			}
		}
	}
}
