using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMarketplace.App.Helper;

public static class ToastHelper
{
    public static async Task DisplayToast(string message, ToastDuration duration = ToastDuration.Short)
    {

        var toast = Toast.Make(message, duration);
        await toast.Show();
    }
}
