using BookShopBLL.ViewModel;

namespace BookShop.Web.Blazor.Service
{
	public class Customer_PromotionService
	{
		private readonly HttpClient _httpClient;
		private readonly Uri _url;
		public Customer_PromotionService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_url = new Uri("https://localhost:7033/api/Customer_Promotion/");
		}

		public async Task<List<Customer_PromotionVM>?> GetAsync(Guid? idcustomer, Guid? idpromotion)
		{
			if (idcustomer != null && idpromotion == null)
			{
				return await _httpClient.GetFromJsonAsync<List<Customer_PromotionVM>>(_url + "all" + $"?idcustomer={idcustomer}");
			}
			else if (idpromotion != null && idcustomer == null)
			{
				return await _httpClient.GetFromJsonAsync<List<Customer_PromotionVM>>(_url + "all" + $"?idpromotion={idpromotion}");
			}
			return await _httpClient.GetFromJsonAsync<List<Customer_PromotionVM>>(_url + "all");
		}

		public async Task<List<Customer_PromotionVM>?> GetActiveAsync(Guid? idcustomer, Guid? idpromotion)
		{
			if (idcustomer != null && idpromotion == null)
			{
				return await _httpClient.GetFromJsonAsync<List<Customer_PromotionVM>>(_url + "active" + $"?idcustomer={idcustomer}");
			}
			else if (idpromotion != null && idcustomer == null)
			{
				return await _httpClient.GetFromJsonAsync<List<Customer_PromotionVM>>(_url + "active" + $"?idpromotion={idpromotion}");
			}
			return await _httpClient.GetFromJsonAsync<List<Customer_PromotionVM>>(_url + "active");
		}

		public async Task<Customer_PromotionVM?> GetByIdAsync(Guid? idcustomer, Guid? idpromotion)
		{
			return await _httpClient.GetFromJsonAsync<Customer_PromotionVM>(_url + $"{idcustomer}/{idpromotion}");
		}

		public async Task<bool> AddAsync(List<Customer_PromotionVM> item)
		{
			var response = await _httpClient.PostAsJsonAsync(_url + "add", item);
			if (response != null) return true;
			return false;
		}

		public async Task<bool> UpdateAsync(Customer_PromotionVM item)
		{
			var response = await _httpClient.PutAsJsonAsync(_url + $"update/{item.Id_Customer}/{item.Id_Promotion}", item);
			if(response != null) return true;
			return false;
		}

		public async Task<bool> DeleteAsync(Guid idcustomer, Guid idpromotion)
		{
			var response = await _httpClient.DeleteAsync(_url + "delete" + $"?idcustomer={idcustomer}&idpromotion={idpromotion}");
			if(response != null) return true;
			return false;
		}
	}
}
