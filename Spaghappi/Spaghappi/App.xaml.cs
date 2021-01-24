using System;
using Spaghappi.Services;
using Spaghappi.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Spaghappi
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        //  DependencyService.Register<MockDataStore>();
            DependencyService.Register<SQLiteDataStore>();

            MainPage = new NavigationPage(new MasterPageView());
            
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
