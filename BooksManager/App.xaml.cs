using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BooksManager.Models;
using BooksManager.Data;

namespace BooksManager
{
    public partial class App : Application
    {
        static BooksDatabase database;
        static public string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "books.db3");
        //static public string dbPath = "/Users/yeawhk/sqlite/test.db3";

        public static UserInfo CurrentUser;

        public static BooksDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new BooksDatabase(dbPath);
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage()
            {
                BindingContext = new UserInfo()
            });
        }
    }
}
