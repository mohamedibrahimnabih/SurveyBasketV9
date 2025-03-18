namespace SurveyBasketV9.Api.Models
{
    public class Poll
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Notes { get; set; }
    }
}
