using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using SQLite;

namespace ToDoList_Xamarin_SQLite.Models
{
    public class Database
    {     
        private readonly SQLiteAsyncConnection _database;
        public Database(string dbPath)
        {
            try
            {
                _database = new SQLiteAsyncConnection(dbPath);
                _database.CreateTableAsync<toDoList>();
            }
            catch (Exception e)
            {
                DisplayAlert("Alert", "You have been alerted: " + e.Message, "OK");
                Debug.WriteLine("Alert: " + e.Message);
            }           
        }

        private void DisplayAlert(string v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }

        public Task<List<toDoList>> GetToDoListAsync()
        {
            return _database.Table<toDoList>().ToListAsync();
        }

        public Task<int> SaveToDoListAsync(toDoList toDo)
        {
            return _database.InsertAsync(toDo);
        }

        public Task<int> DeleteToDoListAsync(toDoList toDo)
        {
            return _database.DeleteAsync(toDo);   
        }
        
        public Task<int> EraseToDoListTableAsync()
        {
            return _database.DeleteAllAsync<toDoList>();
        }
    }
}
