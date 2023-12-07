using ChampManage.MAUI.ViewModels;

namespace ChampManage.MAUI
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel _viewModel;

        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.GetNewsAsync();
        }
    }
}
