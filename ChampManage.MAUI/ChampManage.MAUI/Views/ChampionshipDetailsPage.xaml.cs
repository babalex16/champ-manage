using ChampManage.MAUI.ViewModels;

namespace ChampManage.MAUI.Views;

public partial class ChampionshipDetailsPage : ContentPage
{
	public ChampionshipDetailsPage(ChampionshipDetailsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}