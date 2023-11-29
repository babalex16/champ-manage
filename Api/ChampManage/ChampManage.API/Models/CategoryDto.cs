namespace ChampManage.API.Models
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public int MaxWeight { get; set; }
        public string Belt { get; set; }
        public int FightTimeMinutes { get; set; }
    }
}
