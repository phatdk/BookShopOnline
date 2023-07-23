using BookShopBLL.ViewModel;

namespace BookShop.Web.Blazor.Service
{
	public class WishListService
	{
		private readonly HttpClient _httpClient;
		private readonly Uri _url;
		public WishListService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_url = new Uri("https://localhost:7033/api/Cart/");
		}

		public async Task<List<WishListVM>?> GetAsync(Guid? idcustomer, Guid? idbook)
		{
			if (idcustomer != null && idbook == null) return await _httpClient.GetFromJsonAsync<List<WishListVM>>(_url + $"all?idcustomer={idcustomer}");
			else if (idbook != null && idcustomer == null) return await _httpClient.GetFromJsonAsync<List<WishListVM>>(_url + $"all?idbook={idbook}");
			return await _httpClient.GetFromJsonAsync<List<WishListVM>>(_url + "all");
		}

		public async Task<WishListVM?> GetByIdAsync(Guid idcustomer, Guid idbook)
		{
			return await _httpClient.GetFromJsonAsync<WishListVM>(_url + $"{idcustomer}/{idbook}");
		}

		public async Task<WishListVM?> AddAsync(WishListVM WishListVM)
		{
			var response = await _httpClient.PostAsJsonAsync(_url + "add", WishListVM);
			return await response.Content.ReadFromJsonAsync<WishListVM>();
		}

		public async Task<WishListVM?> UpdateAsync(WishListVM WishListVM)
		{
			var response = await _httpClient.PutAsJsonAsync(_url + $"update/{WishListVM.Id_Customer}/{WishListVM.Id_Book}", WishListVM);
			return await response.Content.ReadFromJsonAsync<WishListVM>();
		}

		public async Task<WishListVM?> DeleteAsync(Guid? idcustomer, Guid? idbook)
		{
			var response = await _httpClient.DeleteAsync(_url + $"delete/{idcustomer}/{idbook}");
			return await response.Content.ReadFromJsonAsync<WishListVM>();
		}
	}
}
