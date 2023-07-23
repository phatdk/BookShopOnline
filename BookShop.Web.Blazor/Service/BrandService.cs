using BookShopBLL.ViewModel;

namespace BookShop.Web.Blazor.Service
{
	public class BrandService
	{
		private readonly HttpClient _httpClient;
		private readonly Uri _url;
		public BrandService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_url = new Uri("https://localhost:7033/api/Brand/");
		}

		public async Task<List<BrandVM>?> GetAsync(string? name)
		{
			if (name == null) return await _httpClient.GetFromJsonAsync<List<BrandVM>>(_url + "all");
			return await _httpClient.GetFromJsonAsync<List<BrandVM>>(_url + "all" + $"?name={name}");
		}

		public async Task<List<BrandVM>?> GetActiveAsync(string? name)
		{
			if (name == null) return await _httpClient.GetFromJsonAsync<List<BrandVM>>(_url + "active");
			return await _httpClient.GetFromJsonAsync<List<BrandVM>>(_url + "active" + $"?name={name}");
		}

		public async Task<BrandVM?> GetByIdAsync(Guid id)
		{
			return await _httpClient.GetFromJsonAsync<BrandVM>(_url + $"{id}");
		}

		public async Task<BrandVM?> AddAsync(BrandVM brandVM)
		{
			var response = await _httpClient.PostAsJsonAsync(_url + "add", brandVM);
			return await response.Content.ReadFromJsonAsync<BrandVM>();
		}
		
		public async Task<BrandVM?> UpdateAsync(BrandVM brandVM)
		{
			var response = await _httpClient.PutAsJsonAsync(_url + $"update/{brandVM.Id}", brandVM);
			return await response.Content.ReadFromJsonAsync<BrandVM>();
		}
		
		public async Task<BrandVM?> DeleteAsync(Guid id)
		{
			var response = await _httpClient.DeleteAsync(_url + $"delete/{id}");
			return await response.Content.ReadFromJsonAsync<BrandVM>();
		}

	}
}
