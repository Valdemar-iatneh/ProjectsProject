using System;
using Xamarin.Forms;
using System.IO;
using Xamarin.Forms.Xaml;

namespace ProjectsProject
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "ImagesDB.db";
        public static Database.DBRepository _database;
        public static Database.DBRepository Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new Database.DBRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return _database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Pages.ProjectsPage());
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
