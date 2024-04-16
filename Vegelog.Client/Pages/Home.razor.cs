using Microsoft.AspNetCore.Components.Authorization;
using Vegelog.Shared.Dto.Response;

namespace Vegelog.Client.Pages
{
    public partial class Home
    {
        private List<VegetableResponseDto> _vegetables = new List<VegetableResponseDto>();
        private bool _isDialogOpen = false;

        protected override async Task OnInitializedAsync()
        {
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
