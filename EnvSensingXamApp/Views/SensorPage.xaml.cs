using System;
using System.Collections.Generic;
using System.Diagnostics;
using EnvSensingXamApp.ViewModels;
using Xamarin.Forms;

namespace EnvSensingXamApp.Views
{
    public partial class SensorPage : ContentPage
    {
        SensorViewModel viewModel;

        public SensorPage(Models.Device _device)
        {
            InitializeComponent();

            BindingContext = viewModel = new SensorViewModel();

            viewModel.LoadItemsCommand.Execute(_device);
        }

        public async void sensorTapped(object sender, ItemTappedEventArgs e)
        {
            Models.Sensor sensor = (Models.Sensor)e.Item;
            if (sensor != null)
            {
                Debug.WriteLine("item selectem name : " + sensor.name);
                await Navigation.PushAsync(new ReadingPage(sensor));
            }
            else
            {
                Debug.WriteLine("nothing selected : " + e.Item.GetType());
            }

        }

    }
}
