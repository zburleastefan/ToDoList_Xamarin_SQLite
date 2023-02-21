using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
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
            collectionView.ItemsSource = await App.Database.GetPeopleAsync();
        }

        async void OnAddClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text))
            {
                await App.Database.SavePersonAsync(new Person
                {
                    Name = nameEntry.Text,

                    Subscribed = subscribed.IsChecked ? "Subcribed" : "Unsubscribed"

                });

                nameEntry.Text = string.Empty;
                subscribed.IsChecked = false;

                collectionView.ItemsSource = await App.Database.GetPeopleAsync();
            }
        }

        async void OnEraseClicked(object sender, EventArgs e)
        {
            var result = await DisplayAlert("Delete All from Database", "Erase all Tasks?", "Yes", "No");
            if (result)
            {
                await App.Database.ErasePersonTableAsync();
                collectionView.ItemsSource = await App.Database.GetPeopleAsync();
            }  

            nameEntry.Text = string.Empty;
            subscribed.IsChecked = false;           
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new AddPersonPage());
            //Main. OpenGoogleCommand;
        }

        async void SwipeItemEdit_Invoked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var person = item.CommandParameter as Person;
            //await Navigation.PushAsync(new AddPersonPage());
            //await App.Database.DeletePersonAsync(person);
            await App.Current.MainPage.DisplayAlert("", "Edited", "OK");
        }

        async void SwipeItemDelete_Invoked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var person = item.CommandParameter as Person;
            var result = await DisplayAlert("Delete", $"Delete {person.Name} from Database?", "Yes", "No");
            if (result)
            {
                await App.Database.DeletePersonAsync(person);
                collectionView.ItemsSource = await App.Database.GetPeopleAsync();
            }
            //await Navigation.PushAsync(new AddPersonPage());
        }
    }
}