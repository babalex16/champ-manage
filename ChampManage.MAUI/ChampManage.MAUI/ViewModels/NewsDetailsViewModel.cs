using ChampManage.MAUI.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampManage.MAUI.ViewModels
{
    [QueryProperty((nameof(News)), "News")]
    public partial class NewsDetailsViewModel : BaseViewModel
    {
        [ObservableProperty]
        public News news;
        public NewsDetailsViewModel()
        {
        }
    }
}
