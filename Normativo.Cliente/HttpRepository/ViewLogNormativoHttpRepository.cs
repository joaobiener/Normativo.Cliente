using Normativo.Cliente.Features;
using Entities.Models;
using Shared.RequestFeatures;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Json;
using System.Text.Json;

namespace Normativo.Cliente.HttpRepository
{
    public class ViewLogNormativoHttpRepository : IViewLogNormativoHttpRepository
	{
		private readonly HttpClient _client;
		private readonly NavigationManager _navManager;
		private readonly JsonSerializerOptions _options =
			new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

		public ViewLogNormativoHttpRepository(HttpClient client, NavigationManager navManager,IConfiguration configuration)
		{
			_client = client;
			_navManager = navManager;

		}

        public async Task<PagingResponse<ViewLogsNormativo>> GetLogsNormativo(ViewLogNormativoParameters viewLogNormativoParameters)
        {
			var queryStringParam = new Dictionary<string, string>
			{
				["pageNumber"] = viewLogNormativoParameters.PageNumber.ToString(),
				["pageSize"] = viewLogNormativoParameters.PageSize.ToString(),
				["searchTerm"] = viewLogNormativoParameters.SearchTerm == null ? string.Empty : viewLogNormativoParameters.SearchTerm,
				["orderBy"] = viewLogNormativoParameters.OrderBy == null ? "" : viewLogNormativoParameters.OrderBy
			};

			var response =
				await _client.GetAsync(QueryHelpers.AddQueryString("ReportLogsNormativo/GetByRequest", queryStringParam));

			var content = await response.Content.ReadAsStringAsync();

			var pagingResponse = new PagingResponse<ViewLogsNormativo>
			{
				Items = JsonSerializer.Deserialize<List<ViewLogsNormativo>>(content, _options),
				MetaData = JsonSerializer.Deserialize<MetaData>(
					response.Headers.GetValues("X-Pagination").First(), _options)
			};

			return pagingResponse;
		}

        public async Task<PagingResponse<string>> GetNomeNormativo(ViewLogNormativoParameters viewLogNormativoParameters)
		{
			var queryStringParam = new Dictionary<string, string>
			{
				["pageNumber"] = viewLogNormativoParameters.PageNumber.ToString(),
				["pageSize"] = viewLogNormativoParameters.PageSize.ToString(),
				["searchTerm"] = viewLogNormativoParameters.SearchTerm == null ? string.Empty : viewLogNormativoParameters.SearchTerm,
				["orderBy"] = viewLogNormativoParameters.OrderBy == null ? "" : viewLogNormativoParameters.OrderBy
			};

			var response =
                await _client.GetAsync(QueryHelpers.AddQueryString("ReportLogsNormativo/GetNormativo", queryStringParam));

            var content = await response.Content.ReadAsStringAsync();

            var pagingResponse = new PagingResponse<string>
            {
                Items = JsonSerializer.Deserialize<List<string>>(content, _options),
                MetaData = JsonSerializer.Deserialize<MetaData>(
                    response.Headers.GetValues("X-Pagination").First(), _options)
            };

            return pagingResponse;
        }
    }
}
