using ChampManage.MAUI.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ChampManage.MAUI.ViewModels
{
    [QueryProperty((nameof(Championship)), "Championship")]
    public partial class ChampionshipDetailsViewModel : BaseViewModel
    {
        [ObservableProperty]
        public Championship championship;
        public ChampionshipDetailsViewModel()
        {
        }
    }
}
