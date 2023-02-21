﻿using System;
using ToDoList_Xamarin_SQLite.Services;
using ToDoList_Xamarin_SQLite.Views;
using ToDoList_Xamarin_SQLite.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace ToDoList_Xamarin_SQLite
{
    public partial class App : Application
    {
        private static Database database;
        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));
                }

                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
