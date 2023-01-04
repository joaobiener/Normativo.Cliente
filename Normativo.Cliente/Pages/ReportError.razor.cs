using Microsoft.AspNetCore.Components;

namespace Normativo.Cliente.Pages
{
    public partial class ReportError
	{
		[Parameter]
		public int ErrorCode { get; set; }

		[Parameter]
		public string? ErrorDescription { get; set; }
	}
}
