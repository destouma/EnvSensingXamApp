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
					Debug.WriteLine("jsonResponse : " + result.devices.Count);

					return result;
				}
				else
				{
					return null;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0}", ex.Message);
				return null;
			}
		}

		public async Task<SensorList> getAllSensorsAsync()
        {
			string deviceUrl = Constants.RestServer + "/api/v1/sensors.json";
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
					Debug.WriteLine("jsonResponse : " + result.sensors.Count);

					return result;
				}
				else
				{
					return null;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0}", ex.Message);
				return null;
			}
		}
	}
}
