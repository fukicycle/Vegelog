using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Vegelog.Shared.Dto.Request;

namespace Vegelog.Client.Pages
{
    public partial class Diary
    {
        private string Title { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
        private string Content { get; set; } = string.Empty;

        [Parameter, SupplyParameterFromQuery(Name = "id")]
        public Guid Id { get; set; }

        private string? _thumbnail = null;

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        private async Task FileOnChanged(InputFileChangeEventArgs e)
        {
            await GetThumbnail(e.File);
        }

        private async Task GetThumbnail(IBrowserFile file)
        {
            string extensionName = Path.GetExtension(file.Name);

            List<string> imageFileTypes = new List<string> { ".png", ".jpg", ".jpeg" };
            if (imageFileTypes.Contains(extensionName))
            {
                var resizedFile = await file.RequestImageFileAsync(file.ContentType, 1280, 720);
                var buf = new byte[resizedFile.Size];
                using (var stream = resizedFile.OpenReadStream())
                {
                    await stream.ReadAsync(buf);
                }
                _thumbnail = Convert.ToBase64String(buf);
            }
        }

        private async Task SaveButtonOnClick()
        {
            LogRequestDto logRequestDto = new LogRequestDto(Title, Content, _thumbnail, Id);
            if (string.IsNullOrEmpty(logRequestDto.Title) || string.IsNullOrEmpty(logRequestDto.Content))
            {
                StateContainer.DialogContent = new Fukicycle.Tool.AppBase.Components.Dialog.DialogContent("タイトルと内容を入力してください。", Fukicycle.Tool.AppBase.Components.Dialog.DialogType.Info);
                return;
            }
            await ExecuteWithHttpRequestAsync(HttpMethod.Post, "logs", logRequestDto);
            NavigationManager.NavigateTo("");
        }

        private void CancelButtonOnClick()
        {
            NavigationManager.NavigateTo("");
        }
    }
}
