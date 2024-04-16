using Microsoft.AspNetCore.Components;
using Vegelog.Shared.Dto.Response;

namespace Vegelog.Client.Pages
{
    public partial class Home
    {
        [Parameter]
        [SupplyParameterFromQuery(Name = "code")]
        public string? Code { get; set; }

        private List<VegetableResponseDto> _vegetables = new List<VegetableResponseDto>();
        private bool _isDialogOpen = false;

        protected override async Task OnInitializedAsync()
        {
        }

        protected override async Task OnParametersSetAsync()
        {
            await ExecuteAsync(CheckAsync, true);
        }

        private async Task CheckAsync()
        {
            if (Code != null)
            {
                await AuthStateProvider.SetCodeAsync(Code);
            }
        }

        private void AddButtonOnClick()
        {
            _isDialogOpen = true;
        }

        private void CancelButtonOnClick()
        {
            _isDialogOpen = false;
        }

        private void OkButtonOnClick(VegetableResponseDto vegetable)
        {
            _vegetables.Add(vegetable);
            _isDialogOpen = false;
        }

        private void CardOnClick(VegetableResponseDto vegetable)
        {
            NavigationManager.NavigateTo($"diary?id={vegetable.Id}");
        }
    }
}
