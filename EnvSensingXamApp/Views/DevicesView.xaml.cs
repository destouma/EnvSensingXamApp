using System;
using System.Collections.Generic;
using EnvSensingXamApp.ViewModels;
using Xamarin.Forms;

namespace EnvSensingXamApp.Views
{
    public partial class DevicesView : ContentView
    {
        DeviceViewModel viewModel;

        public DevicesView()
        {
            InitializeComponent();

            BindingContext = viewModel = new DeviceViewModel();

        }
    }
}
