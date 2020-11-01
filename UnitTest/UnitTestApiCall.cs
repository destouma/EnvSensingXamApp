using EnvSensingXamApp.Data;
using EnvSensingXamApp.Models;
using NUnit.Framework;

namespace UnitTestApiCall
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async System.Threading.Tasks.Task getDevicesAsync()
        {
            ApiManager apiManager = new ApiManager(new ApiService());
            DeviceList deviceList = await apiManager.getAllDevicesAsync();
            Assert.AreNotEqual(0, deviceList.count());
        }

        [Test]
        public async System.Threading.Tasks.Task getSensorsAsync()
        {
            ApiManager apiManager = new ApiManager(new ApiService());
            SensorList sensorList = await apiManager.getAllSensorsByDeviceAsync("123-123-000-000");
            Assert.AreNotEqual(0, sensorList.count());
        }

        [Test]
        public async System.Threading.Tasks.Task getSensorsEmtytyAsync()
        {
            ApiManager apiManager = new ApiManager(new ApiService());
            SensorList sensorList = await apiManager.getAllSensorsByDeviceAsync("999-999-999-999");
            Assert.AreEqual(0, sensorList.count());
        }

        [Test]
        public async System.Threading.Tasks.Task getSensorReadingsAsync()
        {
            ApiManager apiManager = new ApiManager(new ApiService());
            SensorReadingList sensorReadingList = await apiManager.getAllSensorReadingsBySensorAsync("123-123-000-001");
            Assert.AreNotEqual(0, sensorReadingList.count());
        }
    }
}
