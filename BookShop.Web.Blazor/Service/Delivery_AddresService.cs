using BookShopBLL.ViewModel;

namespace BookShop.Web.Blazor.Service
{
	public class Delivery_AddresService
	{
		private readonly HttpClient _httpClient;
		private readonly Uri _url;
		public Delivery_AddresService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_url = new Uri("https://localhost:7033/api/Delivery_Address/");
		}

		public async Task<List<Delivery_AddressVM>?> GetAsync(Guid? idcustomer)
		{
			if (idcustomer == null) return await _httpClient.GetFromJsonAsync<List<Delivery_AddressVM>>(_url + "all");
			return await _httpClient.GetFromJsonAsync<List<Delivery_AddressVM>>(_url + "all" + $"?name={idcustomer}");
		}

		public async Task<List<Delivery_AddressVM>?> GetActiveAsync(Guid? idcustomer)
		{
			if (idcustomer == null) return await _httpClient.GetFromJsonAsync<List<Delivery_AddressVM>>(_url + "active");
			return await _httpClient.GetFromJsonAsync<List<Delivery_AddressVM>>(_url + "active" + $"?name={idcustomer}");
		}

		public async Task<Delivery_AddressVM?> GetByIdAsync(Guid id)
		{
			return await _httpClient.GetFromJsonAsync<Delivery_AddressVM>(_url + $"{id}");
		}

		public async Task<bool> AddAsync(Delivery_AddressVM item)
		{
			var response = await _httpClient.PostAsJsonAsync(_url + "add", item);
			if (response != null) return true;
			return false;
		}

		public async Task<bool> UpdateAsync(Delivery_AddressVM item)
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
