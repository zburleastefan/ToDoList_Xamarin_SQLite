using System;
using Xamarin.Forms;
using ToDoList_Xamarin_SQLite.Models;

namespace ToDoList_Xamarin_SQLite.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetToDoListAsync();
        }

        async void OnAddClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text))
            {
                await App.Database.SaveToDoListAsync(new toDoList
                {
                    Name = nameEntry.Text,
                    Subscribed = subscribed.IsChecked ? "Subcribed" : "Unsubscribed",
                });
                nameEntry.Text = string.Empty;
                subscribed.IsChecked = false;               
                collectionView.ItemsSource = await App.Database.GetToDoListAsync();
            }
        }

        async void OnEraseClicked(object sender, EventArgs e)
        {
            var result = await DisplayAlert("Delete All from Database", "Erase all Tasks?", "Yes", "No");
            if (result)
            {
                await App.Database.EraseToDoListTableAsync();
                collectionView.ItemsSource = await App.Database.GetToDoListAsync();
            }  
            nameEntry.Text = string.Empty;
            subscribed.IsChecked = false;           
        }

        async void SwipeItemEdit_Invoked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var toDoList = item.CommandParameter as toDoList;
            string edit = await DisplayPromptAsync("Edit Task", "Edit task name: ", placeholder: "Type someting or hit Cancel");

            while (edit == string.Empty)
            {
                edit = await DisplayPromptAsync("Edit Task", "Edit task name: ", placeholder: "Type someting or hit Cancel");
            }

            if (edit != null)
            {
                toDoList.Name = edit;
                await App.Database.EditToDoListAsync(toDoList);
                collectionView.ItemsSource = await App.Database.GetToDoListAsync();
            }                      
        }

        async void SwipeItemDelete_Invoked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var toDoList = item.CommandParameter as toDoList;
            var result = await DisplayAlert("Delete", $"Delete '{toDoList.Name}'?", "Yes", "No");
            if (result)
            {
                await App.Database.DeleteToDoListAsync(toDoList);
                collectionView.ItemsSource = await App.Database.GetToDoListAsync();
            }         
        }
    }
}