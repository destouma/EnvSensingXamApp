using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EnvSensingXamApp.Models
{
    public class Device
    {
        [JsonProperty("id")]
        public long id { get; set; }

        [JsonProperty("uuid")]
        public String uuid { get; set; }

        [JsonProperty("name")]
        public String name { get; set; }

        [JsonProperty("description")]
        public String description { get; set; }

        public Device(int _id,
            String _uuid,
            String _name,
            String _description)
        {
            id = _id;
            uuid = _uuid;
            name = _name;
            description = _description;
        }
    }


    public class DeviceList
    {
        [JsonProperty("devices")]
        public List<Device> devices { get; set; }

        public DeviceList()
        {
            devices = new List<Device>();
        }

        public int count()
        {
            return devices.Count;
        }
    }
}
