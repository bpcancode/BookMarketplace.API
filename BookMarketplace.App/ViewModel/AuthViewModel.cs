using BookMarketplace.App.Services;
using BookMarketplace.Shared.Dtos;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMarketplace.App.ViewModel;

public partial class AuthViewModel(IAuthService authService) : BaseViewModel
{
    private readonly IAuthService _authService = authService;

    [ObservableProperty] private string? email;
    [ObservableProperty] private string? password;

    [RelayCommand]
    private async Task Login()
    {
        if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password)) return;

        var dto = new SigninRequestDto(Email, Password);
        try
        {

            var res = await _authService.SigninAsync(dto);
            if (!res.IsSuccess)
            {

            }
            else
            {
                await Shell.Current.GoToAsync("//Dashboard");
            }

        }
        catch (Exception ex)
        {

        }


    }
}
