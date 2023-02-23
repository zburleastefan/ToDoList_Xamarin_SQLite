using SQLite;

namespace ToDoList_Xamarin_SQLite.Models
{
    public class toDoList
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subscribed { get; set; }
    }
}
