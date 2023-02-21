using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Essentials;

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
                _database.CreateTableAsync<Person>();
            }
            catch (Exception e)
            {

                DisplayAlert("Alert", "You have been alerted: " + e.Message, "OK");
                Debug.WriteLine("Alert: " + e.Message);
                //var answer = await DisplayAlert("Question?", "Would you like to play a game", "Yes", "No");
            }
            
        }

        private void DisplayAlert(string v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }

        public Task<List<Person>> GetPeopleAsync()
        {
            return _database.Table<Person>().ToListAsync();
        }

        public Task<int> SavePersonAsync(Person person)
        {
            return _database.InsertAsync(person);
        }

        public Task<int> DeletePersonAsync(Person person)
        {
            return _database.DeleteAsync(person);   
        }
        
        public Task<int> ErasePersonTableAsync()
        {
            return _database.DeleteAllAsync<Person>();
        }
    }
}
