using Entities.Models;
using Microsoft.AspNetCore.Components;


namespace Normativo.Cliente.Components
{
    public partial class ReportLogNormativoTable
	{
		[Parameter]
		public List<ViewLogsNormativo> viewLogsNormativos { get; set; }
	}
}
