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
