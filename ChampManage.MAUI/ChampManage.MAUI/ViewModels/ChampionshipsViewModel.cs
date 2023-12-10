using ChampManage.MAUI.Models;
using ChampManage.MAUI.Services;
using ChampManage.MAUI.Views;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace ChampManage.MAUI.ViewModels
{
    public partial class ChampionshipsViewModel : BaseViewModel
    {
        public ObservableCollection<Championship> ChampionshipsList { get; } = new();
        private readonly ChampionshipService _championshipService;
        public ChampionshipsViewModel(ChampionshipService championshipService)
        {
            Title = "Championships";
            _championshipService = championshipService;
        }

        [RelayCommand]
        public async Task GetChampionshipsAsync()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;
                var championships = await _championshipService.GetChampionships();

                if (championships.Count != 0)
                {
                    ChampionshipsList.Clear();
                }

                foreach (var item in championships)
                {
                    ChampionshipsList.Add(item);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Unable to get championships: {ex.Message}", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        async Task GoToChampionshipDetailsAsync(Championship championship)
        {
            if (championship is null)
            {
                return;
            }
            await Shell.Current.GoToAsync($"{nameof(ChampionshipDetailsPage)}", true,
                new Dictionary<string, object>
                {
                    {"Championship", championship }
                });
        }
    }
}
