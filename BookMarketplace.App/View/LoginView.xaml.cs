using BookMarketplace.App.ViewModel;

namespace BookMarketplace.App.View;

public partial class LoginView : ContentPage
{
    private readonly AuthViewModel _vm;

    public LoginView(AuthViewModel vm)
	{
		InitializeComponent();
        BindingContext = _vm = vm;
    }


}