﻿using BookShopBLL.ViewModel;

namespace BookShop.Web.Blazor.Service
{
	public class Payment_FormService
	{
		private readonly HttpClient _httpClient;
		private readonly Uri _url;
		public Payment_FormService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_url = new Uri("https://localhost:7033/api/Payment_Form/");
		}

		public async Task<List<Payment_FormVM>?> GetAsync()
		{
			return await _httpClient.GetFromJsonAsync<List<Payment_FormVM>>(_url + "all");
		}

		public async Task<List<Payment_FormVM>?> GetActiveAsync()
		{
			return await _httpClient.GetFromJsonAsync<List<Payment_FormVM>>(_url + "active");
		}

		public async Task<Payment_FormVM?> GetByIdAsync(Guid id)
		{
			return await _httpClient.GetFromJsonAsync<Payment_FormVM>(_url + $"{id}");
		}

		public async Task<bool> AddAsync(Payment_FormVM item)
		{
			var response = await _httpClient.PostAsJsonAsync(_url + "add", item);
			if (response != null) return true;
			return false;
		}

		public async Task<bool> UpdateAsync(Payment_FormVM item)
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
