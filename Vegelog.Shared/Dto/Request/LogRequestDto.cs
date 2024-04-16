namespace Vegelog.Shared.Dto.Request
{
    public sealed class LogRequestDto
    {
        public LogRequestDto(string title, string content, string? image, Guid vegetableId)
        {
            Title = title;
            Content = content;
            Image = image;
            VegetableId = vegetableId;
        }

        public string Title { get; }
        public string Content { get; }
        public string? Image { get; }
        public Guid VegetableId { get; }
    }
}
