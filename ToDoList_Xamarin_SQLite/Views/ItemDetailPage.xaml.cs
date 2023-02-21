using System.ComponentModel;
using ToDoList_Xamarin_SQLite.ViewModels;
using Xamarin.Forms;

namespace ToDoList_Xamarin_SQLite.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}