using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using JGPFGit.Views;
using System.IO;

namespace JGPFGit
{
    public partial class App : Application
    {
        static Database database;

        public static Database Database
        {
            get
            {
                if(database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "baza.db"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new StronaGlowna());
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
