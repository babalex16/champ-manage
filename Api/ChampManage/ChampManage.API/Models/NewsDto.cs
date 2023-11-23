namespace ChampManage.API.Models
{
    public class NewsDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public DateTime DateOfArticle { get; set; }

        public string Text { get; set; } = string.Empty;
    }
}
