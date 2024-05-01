using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Vegelog.Shared.Dto.Request;

namespace Vegelog.Client.Pages
{
    public partial class Diary
    {
        [Parameter, SupplyParameterFromQuery(Name = "id")]
        public Guid Id { get; set; }

        private bool _isDialogOpen = false;

        private void OpenDilalog()
        {
            _isDialogOpen = true;
        }

        private void CloseDilalog()
        {
            _isDialogOpen = false;
        }
    }
}
