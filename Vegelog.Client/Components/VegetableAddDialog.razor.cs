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
        public EventCallback<Vegetable> OkButtonOnClick { get; set; }

        private string Name { get; set; } = string.Empty;
        private string? Description { get; set; } = null;

        private async Task VegetableAddButtonOnClick()
        {
            Vegetable vegetable = new Vegetable(Guid.NewGuid(), Name, Description, null);
            await OkButtonOnClick.InvokeAsync(vegetable);
        }
    }
}
