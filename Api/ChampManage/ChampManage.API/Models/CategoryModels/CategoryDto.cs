namespace ChampManage.API.Models.CategoryModels
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public int MaxWeight { get; set; }
        public string Belt { get; set; } = BeltNames.White.ToString();
        public int FightTimeMinutes { get; set; }
    }
}
