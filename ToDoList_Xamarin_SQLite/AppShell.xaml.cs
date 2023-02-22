using System;
using System.Collections.Generic;
using ToDoList_Xamarin_SQLite.ViewModels;
using ToDoList_Xamarin_SQLite.Views;
using Xamarin.Forms;

namespace ToDoList_Xamarin_SQLite
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(ScanBarCode), typeof(ScanBarCode));
            Routing.RegisterRoute(nameof(PlayerPage), typeof(PlayerPage));
        }

    }
}
