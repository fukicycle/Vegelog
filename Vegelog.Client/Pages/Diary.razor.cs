using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Vegelog.Shared.Dto.Request;
using Vegelog.Shared.Dto.Response;

namespace Vegelog.Client.Pages
{
    public partial class Diary
    {
        [Parameter, SupplyParameterFromQuery(Name = "id")]
        public Guid Id { get; set; }

        private bool _isDialogOpen = false;
        private List<VegetableLogResponseDto> _diaries = new List<VegetableLogResponseDto>();
        private string? _image = null;

        protected override async Task OnInitializedAsync()
        {
            _diaries = await ExecuteWithHttpRequestAsync<List<VegetableLogResponseDto>>(HttpMethod.Get, $"logs?vegetableId={Id}", hasLoading: true) ?? new List<VegetableLogResponseDto>();
        }

        private void OpenDilalog()
        {
            _isDialogOpen = true;
        }

        private void CloseDilalog()
        {
            _isDialogOpen = false;
        }

        private void ImageOnClick(string image)
        {
            _image = image;
        }

        private void CloseImage()
        {
            _image = null;
        }
    }
}
