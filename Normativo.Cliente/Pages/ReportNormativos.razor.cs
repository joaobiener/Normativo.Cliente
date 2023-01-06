using Normativo.Cliente.HttpInterceptor;
using Normativo.Cliente.HttpRepository;
using Entities.Models;
using Shared.RequestFeatures;
using Microsoft.AspNetCore.Components;

namespace Normativo.Cliente.Pages
{
	public partial class ReportNormativos : IDisposable
	{
		public List<ViewLogsNormativo> ViewLogNormativoList { get; set; } = new List<ViewLogsNormativo>();

		public List<string> ViewNomeNormativoList { get; set; } = new List<string>();

		public MetaData MetaData { get; set; } = new MetaData();

		private ViewLogNormativoParameters _viewLogNormativoParameters = new ViewLogNormativoParameters();

		[Inject]
		public IViewLogNormativoHttpRepository? ViewLogsNormativoRepo { get; set; }

		[Inject]
		public HttpInterceptorService? Interceptor { get; set; }

		protected async override Task OnInitializedAsync()
		{
			Interceptor.RegisterEvent();
			await GetLogsNormativo();
			await GetNomeNormativos();
		}

		private async Task SelectedPage(int page)
		{
			_viewLogNormativoParameters.PageNumber = page;
			await GetLogsNormativo();
		}

        private async Task GetNomeNormativos()
        {
            var pagingResponse = await ViewLogsNormativoRepo.GetNomeNormativo(_viewLogNormativoParameters);

			ViewNomeNormativoList = pagingResponse.Items;
            MetaData = pagingResponse.MetaData;
        }
        private async Task GetLogsNormativo()
		{
			var pagingResponse = await ViewLogsNormativoRepo.GetLogsNormativo(_viewLogNormativoParameters);

			ViewLogNormativoList = pagingResponse.Items;
			MetaData = pagingResponse.MetaData;
		}

		private async Task SetPageSize(int pageSize)
		{
			_viewLogNormativoParameters.PageSize = pageSize;
			_viewLogNormativoParameters.PageNumber = 1;

			await GetLogsNormativo();
		}

		private async Task SearchChanged(string searchTerm)
		{
			_viewLogNormativoParameters.PageNumber = 1;
			_viewLogNormativoParameters.SearchTerm = searchTerm;

			await GetLogsNormativo();
		}

		private async Task SortChanged(string orderBy)
		{
			_viewLogNormativoParameters.OrderBy = orderBy;

			await GetLogsNormativo();
		}

		public void Dispose() => Interceptor.DisposeEvent();
	}
}
