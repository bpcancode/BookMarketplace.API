using BookMarketplace.App.ViewModel;

namespace BookMarketplace.App.View;

public partial class DashboardView : ContentPage
{
    private readonly DashboardViewModel _vm;

    public DashboardView(DashboardViewModel vm)
	{
		InitializeComponent();
        BindingContext = _vm = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _vm.InitilizeAsync();
    }
}