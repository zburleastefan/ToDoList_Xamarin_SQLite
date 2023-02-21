using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList_Xamarin_SQLite.Models;
using ToDoList_Xamarin_SQLite.ViewModels;
using ToDoList_Xamarin_SQLite.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoList_Xamarin_SQLite.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}