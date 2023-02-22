using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private async void ButtonStart_Clicked(object sender, EventArgs e)
        {
            try
            { DependencyService.Get<IAudioPlayerService>().PlayAudioFile("Music1.mp3"); /*music from Assets folder - Android*/}
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
            { await Browser.OpenAsync("https://music.youtube.com/watch?v=cURqHmXD1b8&list=OLAK5uy_meMYjt8zjeDzNMjTAUyDDf94MqYxxZMTw"); }
            catch (Exception e1)
            { await Application.Current.MainPage.DisplayAlert("Browser error: ", e1.Message, "OK"); }
        }
    }
}