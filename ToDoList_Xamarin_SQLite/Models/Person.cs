using SQLite;

namespace ToDoList_Xamarin_SQLite.Models
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subscribed { get; set; } //bool
    }
}
