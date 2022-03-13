using System;
using System.Collections.Generic;
using System.Diagnostics;
using EnvSensingXamApp.ViewModels;
using Xamarin.Forms;

namespace EnvSensingXamApp.Views
{
    public partial class DevicePage : ContentPage
    {
        DeviceViewModel viewModel;

        public DevicePage()
        {
            InitializeComponent();

            BindingContext = viewModel = new DeviceViewModel();

        }

        public async void deviceTapped(object sender, ItemTappedEventArgs e)
        {
            Models.Device device = (Models.Device)e.Item;
            if (device != null)
            {
                Debug.WriteLine("item selectem name : " + device.name);
                await Navigation.PushAsync(new SensorPage(device));
            }
            else
            {
                Debug.WriteLine("nothing selected : " + e.Item.GetType());
            }

        }


    }
}
