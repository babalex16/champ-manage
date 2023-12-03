using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampManage.MAUI.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateOfArticle { get; set; }
        public string Text { get; set; }

        public string Image => $"Resources/Images/NewsImages/{GetRandomImageName()}";

        private string GetRandomImageName()
        {
            var imageNames = new List<string> { "image1.JPG", "image2.JPG", "image3.JPG", "image4.JPG", "image5.JPG", "image6.JPG", "image7.JPG" };
            var random = new Random();
            return imageNames[random.Next(imageNames.Count)];
        }
    }
}
