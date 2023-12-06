﻿using System;
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

    }
}
