using ChampManage.MAUI.Models;
using CommunityToolkit.Mvvm.ComponentModel;

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
