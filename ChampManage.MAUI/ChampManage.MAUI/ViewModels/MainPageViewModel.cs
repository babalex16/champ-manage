using ChampManage.MAUI.Models;
using ChampManage.MAUI.Services;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;

namespace ChampManage.MAUI.ViewModels
{
    public partial class MainPageViewModel : BaseViewModel
    {
        public ObservableCollection<News> NewsList { get; } = new();
        NewsService _newsService;
        public MainPageViewModel(NewsService newsService)
        {
            _newsService = newsService;
        }

        [RelayCommand]
        public async Task GetNewsAsync()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;
                var news = await _newsService.GetNews();

                if (news.Count != 0) 
                {
                    NewsList.Clear();
                }

                foreach (var item in news)
                {
                    NewsList.Add(item);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error",$"Unable to get news: {ex.Message}", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
