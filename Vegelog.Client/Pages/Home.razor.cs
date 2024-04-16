using Microsoft.AspNetCore.Components;
using Vegelog.Shared.Dto.Response;

namespace Vegelog.Client.Pages
{
    public partial class Home
    {
        private List<VegetableResponseDto> _vegetables = new List<VegetableResponseDto>();
        private bool _isDialogOpen = false;

        protected override async Task OnInitializedAsync()
        {
            await RefreshAsync();
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

        private async Task RefreshAsync()
        {
            string? code = await AuthStateProvider.GetCodeAsync();
            if (code == null) return;
            GroupResponseDto? group = await ExecuteWithHttpRequestAsync<GroupResponseDto>(HttpMethod.Get, $"http://localhost:5204/api/v1/groups?code={code}");
            if (group == null) return;
            _vegetables = group.Vegetables;
        }
    }
}
