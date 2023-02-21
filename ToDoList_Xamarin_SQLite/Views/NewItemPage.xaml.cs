using System;
using System.Collections.Generic;
using System.ComponentModel;
using ToDoList_Xamarin_SQLite.Models;
using ToDoList_Xamarin_SQLite.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoList_Xamarin_SQLite.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}