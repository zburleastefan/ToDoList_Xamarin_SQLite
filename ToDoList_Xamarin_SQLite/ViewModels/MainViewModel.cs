using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ToDoList_Xamarin_SQLite.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            Title = "To Do List";
            OpenGoogleCommand = new Command(async () => await Browser.OpenAsync("https://www.google.com"));      
        }

        public ICommand OpenGoogleCommand { get;}
    }
}