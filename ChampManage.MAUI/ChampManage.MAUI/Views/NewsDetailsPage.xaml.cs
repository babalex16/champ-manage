using ChampManage.MAUI.Models;
using ChampManage.MAUI.ViewModels;

namespace ChampManage.MAUI.Views;


public partial class NewsDetailsPage : ContentPage
{
	public NewsDetailsPage(MainPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

    }
}