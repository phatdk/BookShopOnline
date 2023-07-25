using BookShopBLL.ViewModel;

namespace BookShop.Web.Blazor.Service
{
	public class CommentService
	{
		private readonly HttpClient _httpClient;
		private readonly Uri _url;
		public CommentService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_url = new Uri("https://localhost:7033/api/Comment/");
		}

		public async Task<List<CommentVM>?> GetAsync(Guid? idbook, Guid? idcustomer, Guid? idparents)
		{
			if (idbook != null) return await _httpClient.GetFromJsonAsync<List<CommentVM>>(_url + $"all?idbook={idbook}");
			else if (idcustomer != null) return await _httpClient.GetFromJsonAsync<List<CommentVM>>(_url + $"all?idcustomer={idcustomer}");
			else if (idparents != null) return await _httpClient.GetFromJsonAsync<List<CommentVM>>(_url + $"all?idparents={idparents}");
			return await _httpClient.GetFromJsonAsync<List<CommentVM>>(_url + "all");
		}

		public async Task<CommentVM?> GetByIdAsync(Guid id)
		{
			return await _httpClient.GetFromJsonAsync<CommentVM>(_url + $"{id}");
		}

		public async Task<bool> AddAsync(CommentVM item)
		{
			var response = await _httpClient.PostAsJsonAsync(_url + $"add", item);
			if (response != null) return true;
			return false;
		}

		public async Task<bool> UpdateAsync(CommentVM item)
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
