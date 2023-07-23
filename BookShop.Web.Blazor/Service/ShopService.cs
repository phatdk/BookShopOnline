using BookShopBLL.ViewModel;

namespace BookShop.Web.Blazor.Service
{
	public class ShopService
	{
		private readonly HttpClient _httpClient;
		private readonly Uri _url;
		public ShopService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_url = new Uri("https://localhost:7033/api/Shop/");
		}

		public async Task<List<ShopVM>?> GetAsync()
		{
			return await _httpClient.GetFromJsonAsync<List<ShopVM>>(_url + $"all");
		}

		public async Task<ShopVM?> GetByIdAsync(Guid id)
		{
			return await _httpClient.GetFromJsonAsync<ShopVM>(_url + $"{id}");
		}

		public async Task<ShopVM?> AddAsync(ShopVM item)
		{
			var response = await _httpClient.PostAsJsonAsync(_url + $"add", item);
			return await response.Content.ReadFromJsonAsync<ShopVM>();
		}

		public async Task<ShopVM?> UpdateAsync(ShopVM item)
		{
			var response = await _httpClient.PutAsJsonAsync(_url + $"update/{item.Id}", item);
			return await response.Content.ReadFromJsonAsync<ShopVM>();
		}

		public async Task<ShopVM?> AddAsync(Guid id)
		{
			var response = await _httpClient.DeleteAsync(_url + $"delete/{id}");
			return await response.Content.ReadFromJsonAsync<ShopVM>();
		}
	}
}
