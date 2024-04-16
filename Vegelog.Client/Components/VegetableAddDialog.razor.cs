using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Vegelog.Shared.Dto.Request;
using Vegelog.Shared.Dto.Response;

namespace Vegelog.Client.Components
{
    public partial class VegetableAddDialog
    {
        [Parameter]
        public EventCallback<MouseEventArgs> CancelButtonOnClick { get; set; }

        [Parameter]
        public EventCallback<VegetableRequestDto> OkButtonOnClick { get; set; }

        private string Name { get; set; } = string.Empty;
        private string? Description { get; set; } = null;

        private async Task VegetableAddButtonOnClick()
        {
            string? code = await AuthStateProvider.GetCodeAsync();
            VegetableRequestDto vegetable = new VegetableRequestDto(Name, Description, code);
            await OkButtonOnClick.InvokeAsync(vegetable);
        }
    }
}
