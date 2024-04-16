using Vegelog.Shared;
using Vegelog.Shared.Dto.Request;
using Vegelog.Shared.Dto.Response;

namespace Vegelog.Client.Components
{
    public partial class InputCodeDialog
    {
        private string InputCode { get; set; } = string.Empty;

        private async Task ApplyButtonOnClick()
        {
            if (string.IsNullOrEmpty(InputCode))
            {
                StateContainer.DialogContent = new Fukicycle.Tool.AppBase.Components.Dialog.DialogContent("コードが入力されていません。", Fukicycle.Tool.AppBase.Components.Dialog.DialogType.Info);
            }
            else
            {
                await AuthStateProvider.SetCodeAsync(InputCode);
                NavigationManager.NavigateTo("", true);
            }
        }

        private async Task NewButtonOnClick()
        {
            RegisteredGroupResponseDto? registered = await ExecuteWithHttpRequestAsync<RegisteredGroupResponseDto, GroupRequestDto>(HttpMethod.Post, "groups", new GroupRequestDto(null));
            if (registered != null)
            {
                await AuthStateProvider.SetCodeAsync(registered.Code);
                NavigationManager.NavigateTo("", true);
            }
        }
    }
}
