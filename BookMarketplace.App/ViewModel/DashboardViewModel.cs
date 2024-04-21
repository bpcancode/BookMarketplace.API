using BookMarketplace.App.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMarketplace.App.ViewModel;

public partial class DashboardViewModel : BaseViewModel
{
    //private readonly IBookService _bookService = bookService;


    [ObservableProperty] private List<string> genres = [
        "For you",
        "Sciene Fiction",
        "Educational",
        ];

    public async Task InitilizeAsync()
    {

    }
}
