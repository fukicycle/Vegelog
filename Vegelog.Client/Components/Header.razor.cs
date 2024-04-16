
namespace Vegelog.Client.Components
{
    public partial class Header
    {
        string? _code;
        protected override async Task OnInitializedAsync()
        {
            _code = await ExecuteAsync(AuthStateProvider.GetCodeAsync, true);
        }
    }
}
