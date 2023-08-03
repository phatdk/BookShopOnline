using BookShopBLL.ViewModel;

namespace BookShop.Web.Blazor.Service
{
	public class EvaluateService
	{
		private readonly HttpClient _httpClient;
		private readonly Uri _url;
		public EvaluateService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_url = new Uri("https://localhost:7033/api/Evaluate/");
		}

		public async Task<List<EvaluateVM>?> GetAsync(Guid? idbook, Guid? idcustomer)
		{
			if (idcustomer != null && idbook == null) return await _httpClient.GetFromJsonAsync<List<EvaluateVM>>(_url + $"all?idcustomer={idcustomer}");
			else if (idbook != null && idcustomer == null) return await _httpClient.GetFromJsonAsync<List<EvaluateVM>>(_url + $"all?idbook={idbook}");
			return await _httpClient.GetFromJsonAsync<List<EvaluateVM>>(_url + "all");
		}

		public async Task<EvaluateVM?> GetByIdAsync(Guid id)
		{
			return await _httpClient.GetFromJsonAsync<EvaluateVM>(_url + $"{id}");
		}

		public async Task<bool> AddAsync(EvaluateVM item)
		{
			var response = await _httpClient.PostAsJsonAsync(_url + "add", item);
			if (response != null) return true;
			return false;
		}

		public async Task<bool> UpdateAsync(EvaluateVM item)
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
