using Vegelog.Shared.Dto.Response;

namespace Vegelog.Client.Pages
{
    public partial class Home
    {
        private List<Vegetable> _vegetables = new List<Vegetable>();

        protected override void OnInitialized()
        {
            base.OnInitialized();
            _vegetables.Add(new Vegetable(Guid.Empty, "ピーマン", "おいしいピーマンに育ってくれるはずおいしいピーマンに育ってくれるはずおいしいピーマンに育ってくれるはずおいしいピーマンに育ってくれるはずおいしいピーマンに育ってくれるはずおいしいピーマンに育ってくれるはず", null));
            _vegetables.Add(new Vegetable(Guid.Empty, "ピーマン", "おいしいピーマンに育ってくれるはずおいしいピーマンに育ってくれるはずおいしいピーマンに育ってくれるはずおいしいピーマンに育ってくれるはずおいしいピーマンに育ってくれるはずおいしいピーマンに育ってくれるはず", null));
            _vegetables.Add(new Vegetable(Guid.Empty, "ピーマン", "おいしいピーマンに育ってくれるはずおいしいピーマンに育ってくれるはずおいしいピーマンに育ってくれるはずおいしいピーマンに育ってくれるはずおいしいピーマンに育ってくれるはずおいしいピーマンに育ってくれるはず", null));
        }
    }
}
