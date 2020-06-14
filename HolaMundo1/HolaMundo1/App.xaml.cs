using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HolaMundo1.Services;
using HolaMundo1.Views;

namespace HolaMundo1
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
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
