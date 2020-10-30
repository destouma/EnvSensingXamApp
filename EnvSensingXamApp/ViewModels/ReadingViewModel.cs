using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using EnvSensingXamApp.Data;
using EnvSensingXamApp.Models;
using Xamarin.Forms;

namespace EnvSensingXamApp.ViewModels
{
    public class ReadingViewModel : BaseViewModel
    {
        public Command LoadItemsCommand { get; set; }

        private ApiManager apiManager { get; set; }

        private ObservableCollection<SensorReadingDisplay> items;
        public ObservableCollection<SensorReadingDisplay> Items
        {
            get { return items; }
            set
            {
                items = value;
            }
        }

        public ReadingViewModel()
        {
            apiManager = new ApiManager(new ApiService());

            Items = new ObservableCollection<SensorReadingDisplay>();

            LoadItemsCommand = new Command<Sensor>(async (sensor) => await ExecuteLoadItemsCommand(sensor));

        }

        async Task ExecuteLoadItemsCommand(Sensor sensor)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                SensorReadingList sensorReadingList = await apiManager.getAllSensorReadingsBySensorAsync(sensor.uuid);
                foreach (SensorReading reading in sensorReadingList.sensorReadings)
                { 
                    Items.Add(new SensorReadingDisplay(reading));
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