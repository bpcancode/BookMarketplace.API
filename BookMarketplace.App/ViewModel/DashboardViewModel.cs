using BookMarketplace.App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMarketplace.App.ViewModel;

public partial class DashboardViewModel(IBookService bookService) : BaseViewModel
{
    private readonly IBookService _bookService = bookService;

    public async Task InitilizeAsync()
    {

    }
}
