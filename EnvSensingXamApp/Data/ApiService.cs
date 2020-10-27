using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using EnvSensingXamApp.Models;
using Newtonsoft.Json;

namespace EnvSensingXamApp.Data
{
    public class ApiService : IApiService
    {
        HttpClient client;

        public ApiService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
        }

        public async Task<DeviceList> getAllDevicesAsync()
        {
			string deviceUrl = Constants.RestServer + "/api/v1/devices.json";
			var deviceUri = new Uri(string.Format(deviceUrl));
			try
			{
				HttpResponseMessage response = null;

				response = await client.GetAsync(deviceUri);
				Debug.WriteLine("response : " + response.ToString());
				if (response.StatusCode == System.Net.HttpStatusCode.OK)
				{
					var jsonResponse = await response.Content.ReadAsStringAsync();
					Debug.WriteLine("jsonResponse : " + jsonResponse);

					var result = JsonConvert.DeserializeObject<DeviceList>(jsonResponse);
					Debug.WriteLine("jsonResponse : " + result.count());

					return result;
				}
				else
				{
					return null;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine("				ERROR :" + ex.Message);
				return null;
			}
		}

		public async Task<SensorList> getAllSensorsByDeviceAsync(String uuid)
        {
			string deviceUrl = Constants.RestServer + "/api/v1/sensors.json?uuid=" + uuid;
			var deviceUri = new Uri(string.Format(deviceUrl));
			try
			{
				HttpResponseMessage response = null;

				response = await client.GetAsync(deviceUri);
				Debug.WriteLine("response : " + response.ToString());
				if (response.StatusCode == System.Net.HttpStatusCode.OK)
				{
					var jsonResponse = await response.Content.ReadAsStringAsync();
					Debug.WriteLine("jsonResponse : " + jsonResponse);

					var result = JsonConvert.DeserializeObject<SensorList>(jsonResponse);
					Debug.WriteLine("jsonResponse : " + result.count());

					return result;
				}
				else
				{
					return null;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine("				ERROR :" + ex.Message);
				return null;
			}
		}

		public async Task<SensorReadingList> getAllSensorReadingsBySensorAsync(String uuid)
		{
			string deviceUrl = Constants.RestServer + "/api/v1/sensor_readings.json?uuid=" + uuid;
			var deviceUri = new Uri(string.Format(deviceUrl));
			try
			{
				HttpResponseMessage response = null;

				response = await client.GetAsync(deviceUri);
				Debug.WriteLine("response : " + response.ToString());
				if (response.StatusCode == System.Net.HttpStatusCode.OK)
				{
					var jsonResponse = await response.Content.ReadAsStringAsync();
					Debug.WriteLine("jsonResponse : " + jsonResponse);

					var result = JsonConvert.DeserializeObject<SensorReadingList>(jsonResponse);
					Debug.WriteLine("jsonResponse : " + result.count());

					return result;
				}
				else
				{
					return null;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine("				ERROR :" + ex.Message);
				return null;
			}
		}

    }
}
