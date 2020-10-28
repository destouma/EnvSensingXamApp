using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using EnvSensingXamApp.Data;
using EnvSensingXamApp.Models;

namespace EnvSensingXamApp.ViewModels
{
    public class DeviceViewModel : BaseViewModel
    {
        private ApiManager apiManager { get; set; }

        string textLabel = string.Empty;

        public string TextLabel
        {
            get { return textLabel; }
            set { SetProperty(ref textLabel, value); }
        }

        private ObservableCollection<Device> items;
        public ObservableCollection<Device> Items
        {
            get { return items; }
            set
            {
                items = value;
            }
        }

        public DeviceViewModel()
        {
            apiManager = new ApiManager(new ApiService());

            TextLabel = "Test Label From View Model";
            Items = new ObservableCollection<Device>();

            init();
        }

        private async void init()
        {
            DeviceList deviceList = await apiManager.getAllDevicesAsync();
            foreach (Device device in deviceList.devices)
            {
                Debug.WriteLine("device name : " + device.name);
                Items.Add(device);
            }
        }
    }
}
