using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Vegelog.Shared.Dto.Response;

namespace Vegelog.Client.Components
{
    public partial class VegetableAddDialog
    {
        [Parameter]
        public EventCallback<MouseEventArgs> CancelButtonOnClick { get; set; }

        [Parameter]
        public EventCallback<VegetableResponseDto> OkButtonOnClick { get; set; }

        private string Name { get; set; } = string.Empty;
        private string? Description { get; set; } = null;

        private async Task VegetableAddButtonOnClick()
        {
            VegetableResponseDto vegetable = new VegetableResponseDto(Guid.NewGuid(), Name, Description, null);
            await OkButtonOnClick.InvokeAsync(vegetable);
        }
    }
}
