using ChampManage.MAUI.ViewModels;

namespace ChampManage.MAUI.Views
{
    public partial class ChampionshipsPage : ContentPage
    {
	    ChampionshipsViewModel _viewModel;

	    public ChampionshipsPage(ChampionshipsViewModel viewModel)
	    {
		    InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.GetChampionshipsAsync();
        }
    }
}