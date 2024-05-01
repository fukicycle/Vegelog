namespace Vegelog.Shared.Dto.Response
{
    public sealed class VegetableLogResponseDto
    {
        public VegetableLogResponseDto(string? thumbnail, string comment, string title, DateTime registerDateTime)
        {
            Thumbnail = thumbnail;
            Comment = comment;
            Title = title;
            RegisterDateTime = registerDateTime;
        }
        public string? Thumbnail { get; }
        public string Comment { get; }
        public string Title { get; }
        public DateTime RegisterDateTime { get; }
    }
}
