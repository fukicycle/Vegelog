using Microsoft.AspNetCore.Components;

namespace Vegelog.Client.Pages
{
    public partial class Diary
    {
        private string Title { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
        private string Content { get; set; } = string.Empty;

        [Parameter, SupplyParameterFromQuery(Name = "id")]
        public Guid Id { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Content = Id.ToString();
        }
    }
}
