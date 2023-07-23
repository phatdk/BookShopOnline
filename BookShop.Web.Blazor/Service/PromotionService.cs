using BookShopBLL.ViewModel;

namespace BookShop.Web.Blazor.Service
{
	public class PromotionService
	{
		private readonly HttpClient _httpClient;
		private readonly Uri _url;
		public PromotionService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_url = new Uri("https://localhost:7033/api/Promotion/");
		}

		public async Task<List<PromotionVM>?> GetAsync(Guid? idtype)
		{
			if (idtype == null) return await _httpClient.GetFromJsonAsync<List<PromotionVM>>(_url + $"all");
			return await _httpClient.GetFromJsonAsync<List<PromotionVM>>(_url + $"all?idtype={idtype}");
		}

		public async Task<List<PromotionVM>?> GetActiveAsync(Guid? idtype)
		{
			if (idtype == null) return await _httpClient.GetFromJsonAsync<List<PromotionVM>>(_url + $"active");
			return await _httpClient.GetFromJsonAsync<List<PromotionVM>>(_url + $"active?idtype={idtype}");
		}

		public async Task<PromotionVM?> GetByIdAsync(Guid? id, string? code)
		{
			if (id != null) return await _httpClient.GetFromJsonAsync<PromotionVM>(_url + $"get?id={id}");
			return await _httpClient.GetFromJsonAsync<PromotionVM>(_url + $"get?code={code}");
		}

		public async Task<PromotionVM?> AddAsync(PromotionVM item)
		{
			var response = await _httpClient.PostAsJsonAsync(_url + $"add", item);
			return await response.Content.ReadFromJsonAsync<PromotionVM>();
		}

		public async Task<PromotionVM?> UpdateAsync(PromotionVM item)
		{
			var response = await _httpClient.PutAsJsonAsync(_url + $"update/{item.Id}", item);
			return await response.Content.ReadFromJsonAsync<PromotionVM>();
		}

		public async Task<PromotionVM?> AddAsync(Guid id)
		{
			var response = await _httpClient.DeleteAsync(_url + $"delete/{id}");
			return await response.Content.ReadFromJsonAsync<PromotionVM>();
		}
	}
}
