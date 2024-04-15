using Vegelog.Shared.Dto.Response;

namespace Vegelog.Client.Pages
{
    public partial class Home
    {
        private List<Vegetable> _vegetables = new List<Vegetable>();
        private bool _isDialogOpen = false;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            _vegetables.Add(new Vegetable(Guid.Empty, "ピーマン", "おいしいピーマンに育ってくれるはずおいしいピーマンに育ってくれるはずおいしいピーマンに育ってくれるはずおいしいピーマンに育ってくれるはずおいしいピーマンに育ってくれるはずおいしいピーマンに育ってくれるはず", null));
            _vegetables.Add(new Vegetable(Guid.Empty, "ピーマン", "おいしいピーマンに育ってくれるはずおいしいピーマンに育ってくれるはずおいしいピーマンに育ってくれるはずおいしいピーマンに育ってくれるはずおいしいピーマンに育ってくれるはずおいしいピーマンに育ってくれるはず", null));
            _vegetables.Add(new Vegetable(Guid.Empty, "ピーマン", "おいしいピーマンに育ってくれるはずおいしいピーマンに育ってくれるはずおいしいピーマンに育ってくれるはずおいしいピーマンに育ってくれるはずおいしいピーマンに育ってくれるはずおいしいピーマンに育ってくれるはず", null));
        }

        private void AddButtonOnClick()
        {
            _isDialogOpen = true;
        }

        private void CancelButtonOnClick()
        {
            _isDialogOpen = false;
        }

        private void OkButtonOnClick(Vegetable vegetable)
        {
            _vegetables.Add(vegetable);
            _isDialogOpen = false;
        }

        private void CardOnClick(Vegetable vegetable)
        {
            NavigationManager.NavigateTo($"diary?id={vegetable.Id}");
        }
    }
}
