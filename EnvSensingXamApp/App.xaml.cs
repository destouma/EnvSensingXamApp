﻿using System;
using EnvSensingXamApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnvSensingXamApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new SplashPage());
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
