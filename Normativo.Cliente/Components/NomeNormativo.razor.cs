using Entities.Models;
using Microsoft.AspNetCore.Components;

namespace Normativo.Cliente.Components
{
    public partial class NomeNormativo
	{

        [Parameter]
        public List<string> NomeNormativoList { get; set; }

		[Parameter]
		public EventCallback<string> OnSelectChanged { get; set; }

		async Task OnSelectAsync(ChangeEventArgs e)
		{
			if (e.Value.ToString() == "-1")
				return;

			await OnSelectChanged.InvokeAsync(e.Value.ToString());
		}


	}
}
