using System;
using ToDoList_Xamarin_SQLite.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoList_Xamarin_SQLite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerPage : ContentPage
    {
        public PlayerPage()
        {
            InitializeComponent();
            lbPinkPanter.Text += Environment.NewLine + "https://www.youtube.com/watch?v=lp6z3s1Gig0";
        }

        private async void ButtonStart_Clicked(object sender, EventArgs e)
        {
            try
            { DependencyService.Get<IAudioPlayerService>().PlayAudioFile("the-pink-panther-theme-music.mp3"); /*music from Assets folder - Android*/}
            catch (Exception e1)
            { await Application.Current.MainPage.DisplayAlert("player set path error: ", e1.Message, "OK"); }
        }

        private async void ButtonStop_Clicked(object sender, EventArgs e)
        {
            try
            { DependencyService.Get<IAudioPlayerService>().Stop(); }
            catch (Exception e1)
            { await Application.Current.MainPage.DisplayAlert("player Stop error: ", e1.Message, "OK"); }
        }

        private async void ButtonPause_Clicked(object sender, EventArgs e)
        {
            try
            { DependencyService.Get<IAudioPlayerService>().Pause(); }
            catch (Exception e1)
            { await Application.Current.MainPage.DisplayAlert("player Pause error: ", e1.Message, "OK"); }
        } 
        
        private async void ButtonBrowser_Clicked(object sender, EventArgs e)
        {
            try
            { await Browser.OpenAsync("https://music.youtube.com"); }
            catch (Exception e1)
            { await Application.Current.MainPage.DisplayAlert("Browser error: ", e1.Message, "OK"); }
        }
    }
}