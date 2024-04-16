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
                GroupCheckResponseDto? groupCheckResponseDto = await ExecuteWithHttpRequestAsync<GroupCheckResponseDto>(HttpMethod.Get, $"groups/check?code={InputCode}");
                if (groupCheckResponseDto != null)
                {
                    if (groupCheckResponseDto.IsExists)
                    {
                        //ここでは絶対にNullにならない
                        await AuthStateProvider.SetCodeAsync(groupCheckResponseDto.Code!);
                        NavigationManager.NavigateTo("", true);
                    }
                    else
                    {
                        StateContainer.DialogContent = new Fukicycle.Tool.AppBase.Components.Dialog.DialogContent("無効なコードが入力されました。入力内容を確認してください。", Fukicycle.Tool.AppBase.Components.Dialog.DialogType.Info);
                    }
                }
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
