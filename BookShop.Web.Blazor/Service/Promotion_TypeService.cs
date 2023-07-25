using BookShopBLL.ViewModel;

namespace BookShop.Web.Blazor.Service
{
	public class Promotion_TypeService
	{
		private readonly HttpClient _httpClient;
		private readonly Uri _url;
		public Promotion_TypeService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_url = new Uri("https://localhost:7033/api/Promotion_Type/");
		}

		public async Task<List<Promotion_TypeVM>?> GetAsync()
		{
			return await _httpClient.GetFromJsonAsync<List<Promotion_TypeVM>>(_url + $"all");
		}

		public async Task<List<Promotion_TypeVM>?> GetActiveAsync()
		{
			return await _httpClient.GetFromJsonAsync<List<Promotion_TypeVM>>(_url + $"active");
		}

		public async Task<Promotion_TypeVM?> GetByIdAsync(Guid id)
		{
			return await _httpClient.GetFromJsonAsync<Promotion_TypeVM>(_url + $"{id}");
		}

		public async Task<bool> AddAsync(Promotion_TypeVM item)
		{
			var response = await _httpClient.PostAsJsonAsync(_url + $"add", item);
			if (response != null) return true;
			return false;
		}

		public async Task<bool> UpdateAsync(Promotion_TypeVM item)
		{
			var response = await _httpClient.PutAsJsonAsync(_url + $"update/{item.Id}", item);
			if (response != null) return true;
			return false;
		}

		public async Task<bool> AddAsync(Guid id)
		{
			var response = await _httpClient.DeleteAsync(_url + $"delete/{id}");
			if (response != null) return true;
			return false;
		}
	}
}
