﻿using BookShopBLL.ViewModel;

namespace BookShop.Web.Blazor.Service
{
	public class ImageService
	{
		private readonly HttpClient _httpClient;
		private readonly Uri _url;
		public ImageService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_url = new Uri("https://localhost:7033/api/Image/");
		}

		public async Task<List<ImageVM>?> GetAsync(Guid? idparents)
		{
			if (idparents == null) return await _httpClient.GetFromJsonAsync<List<ImageVM>>(_url + $"all");
			return await _httpClient.GetFromJsonAsync<List<ImageVM>>(_url + $"all?idparents={idparents}");
		}

		public async Task<ImageVM?> GetByIdAsync(Guid id)
		{
			return await _httpClient.GetFromJsonAsync<ImageVM>(_url + $"{id}");
		}

		public async Task<ImageVM?> AddAsync(ImageVM item)
		{
			var response = await _httpClient.PostAsJsonAsync(_url + $"add", item);
			return await response.Content.ReadFromJsonAsync<ImageVM>();
		}

		public async Task<ImageVM?> UpdateAsync(ImageVM item)
		{
			var response = await _httpClient.PutAsJsonAsync(_url + $"update/{item.Id}", item);
			return await response.Content.ReadFromJsonAsync<ImageVM>();
		}

		public async Task<ImageVM?> AddAsync(Guid id)
		{
			var response = await _httpClient.DeleteAsync(_url + $"delete/{id}");
			return await response.Content.ReadFromJsonAsync<ImageVM>();
		}
	}
}
