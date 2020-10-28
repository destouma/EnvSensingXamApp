using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using EnvSensingXamApp.ViewModels;
using EnvSensingXamApp.Views;

namespace EnvSensingXamApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        MainViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MainViewModel();

            BodyContent.Content = new DevicesView();

        }

    }
}
