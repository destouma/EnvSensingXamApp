using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnvSensingXamApp.ViewModels;
using Xamarin.Forms;

namespace EnvSensingXamApp.Views
{
    public partial class SplashPage : ContentPage
    {
        SplashViewModel viewModel;

        public SplashPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();
            BindingContext = viewModel = new SplashViewModel();

            AutoRedirect();
        }

        async void AutoRedirect()
        {
            await Task.Delay(5000);

            Application.Current.MainPage = new NavigationPage(new MainPage());
            
        }
    }
}
