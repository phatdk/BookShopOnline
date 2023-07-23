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

		public async Task<CommentVM?> AddAsync(CommentVM comment)
		{
			var response = await _httpClient.PostAsJsonAsync(_url + "add", comment);
			return await response.Content.ReadFromJsonAsync<CommentVM>();
		}
		
		public async Task<CommentVM?> UpdateAsync(CommentVM comment)
		{
			var response = await _httpClient.PutAsJsonAsync(_url +$"update/{comment.Id}", comment);
			return await response.Content.ReadFromJsonAsync<CommentVM>();
		}
		
		public async Task<CommentVM?> deleteAsync(Guid id)
		{
			var response = await _httpClient.DeleteAsync(_url + $"delete/{id}");
			return await response.Content.ReadFromJsonAsync<CommentVM>();
		}

	}
}
