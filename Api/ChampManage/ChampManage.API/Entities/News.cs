using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChampManage.API.Entities
{
    public class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateOfArticle { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
