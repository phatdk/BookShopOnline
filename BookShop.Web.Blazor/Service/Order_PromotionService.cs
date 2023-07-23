using BookShopBLL.ViewModel;

namespace BookShop.Web.Blazor.Service
{
	public class Order_PromotionService
	{
		private readonly HttpClient _httpClient;
		private readonly Uri _url;
		public Order_PromotionService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_url = new Uri("https://localhost:7033/api/Order_Promotion");
		}

		public async Task<List<Order_PromotionVM>?> GetAsync(Guid? idorder, Guid? idpromotion)
		{
			if (idorder != null && idpromotion == null) return await _httpClient.GetFromJsonAsync<List<Order_PromotionVM>>(_url + "all" + $"?idorder={idorder}");
			else if (idpromotion != null && idorder == null) return await _httpClient.GetFromJsonAsync<List<Order_PromotionVM>>(_url + "all" + $"?idpromotion={idpromotion}");
			return await _httpClient.GetFromJsonAsync<List<Order_PromotionVM>>(_url + "all");
		}

		public async Task<Order_PromotionVM?> GetByIdAsync(Guid idorder, Guid idpromotion)
		{
			return await _httpClient.GetFromJsonAsync<Order_PromotionVM>(_url + $"{idorder}/{idpromotion}");
		}

		public async Task<Order_PromotionVM?> AddAsync(List<Order_PromotionVM> obj)
		{
			var response = await _httpClient.PostAsJsonAsync(_url + "add", obj);
			return await response.Content.ReadFromJsonAsync<Order_PromotionVM>();
		}

		public async Task<Order_PromotionVM?> UpdateAsync(Order_PromotionVM obj)
		{
			var response = await _httpClient.PutAsJsonAsync(_url + $"update/{obj.Id_Order} / {obj.Id_Promotion}", obj);
			return await response.Content.ReadFromJsonAsync<Order_PromotionVM>();
		}

		public async Task<Order_PromotionVM?> DeleteAsync(Guid idorder, Guid? idpromotion)
		{
			if (idpromotion == null)
			{
				var response = await _httpClient.DeleteAsync(_url + $"delete" + $"?idorder={idorder}");
				return await response.Content.ReadFromJsonAsync<Order_PromotionVM>();
			}
			else
			{
				var response = await _httpClient.DeleteAsync(_url + "delete" + $"?idorder={idorder}&idpromotion{idpromotion}");
				return await response.Content.ReadFromJsonAsync<Order_PromotionVM>();
			}
		}
	}
}
