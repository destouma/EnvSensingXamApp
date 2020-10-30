using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using EnvSensingXamApp.Data;
using EnvSensingXamApp.Models;
using Xamarin.Forms;

namespace EnvSensingXamApp.ViewModels
{
    public class SensorViewModel : BaseViewModel
    {
        public Command LoadItemsCommand { get; set; }

        private ApiManager apiManager { get; set; }

        private ObservableCollection<Sensor> items;
        public ObservableCollection<Sensor> Items
        {
            get { return items; }
            set
            {
                items = value;
            }
        }

        public SensorViewModel()
        {
            apiManager = new ApiManager(new ApiService());

            Items = new ObservableCollection<Sensor>();

            LoadItemsCommand = new Command<Models.Device>(async (device) => await ExecuteLoadItemsCommand(device));
        }


        async Task ExecuteLoadItemsCommand(Models.Device device)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                SensorList sensorList = await apiManager.getAllSensorsByDeviceAsync(device.uuid);
                foreach (Sensor sensor in sensorList.sensors)
                {
                    Items.Add(sensor);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
