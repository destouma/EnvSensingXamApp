using System;
using System.Threading.Tasks;
using EnvSensingXamApp.Models;

namespace EnvSensingXamApp.Data
{
    public class ApiManager
    {
        IApiService apiService;

        public ApiManager(IApiService service)
        {
            apiService = service;
        }

        public Task<DeviceList> getAllDevicesAsync()
        {
            return apiService.getAllDevicesAsync();
        }

        public Task<SensorList> getAllSensorsAsync()
        {
            return apiService.getAllSensorsAsync();
        }
    }
}
