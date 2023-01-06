using Normativo.Cliente.Features;
using Entities.Models;
using Shared.RequestFeatures;


namespace Normativo.Cliente.HttpRepository
{
    public interface IViewLogNormativoHttpRepository
	{
		Task<PagingResponse<ViewLogsNormativo>> GetLogsNormativo(ViewLogNormativoParameters viewLogNormativoParameters,Dictionary<string,string> nomeNormativoParam);
        Task<PagingResponse<string>> GetNomeNormativo(ViewLogNormativoParameters viewLogNormativoParameters);

	}
}
