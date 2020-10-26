using System;
using System.Threading.Tasks;
using EnvSensingXamApp.Models;

namespace EnvSensingXamApp.Data
{
    public interface IApiService
    {
        Task<DeviceList> getAllDevicesAsync();

        Task<SensorList> getAllSensorsAsync();
    }
}
