﻿using System;
using System.Collections.Generic;
using System.Text;
using ToDoList_Xamarin_SQLite.Views;
using Xamarin.Forms;

namespace ToDoList_Xamarin_SQLite.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }
    }
}
