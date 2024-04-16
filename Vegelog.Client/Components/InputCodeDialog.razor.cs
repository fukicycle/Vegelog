using Vegelog.Shared;

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
            string code = CodeGenerator.Run();
            await AuthStateProvider.SetCodeAsync(code);
            NavigationManager.NavigateTo("", true);
        }
    }
}
