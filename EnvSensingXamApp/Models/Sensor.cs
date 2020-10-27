using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EnvSensingXamApp.Models
{
    public class Sensor
    {
        [JsonProperty("id")]
        public long id { get; set; }

        [JsonProperty("uuid")]
        public String uuid { get; set; }

        [JsonProperty("name")]
        public String name { get; set; }

        [JsonProperty("description")]
        public String description { get; set; }

        [JsonProperty("sensor_type")]
        public SensorType sensorType { get; set; }

        public Sensor(int _id,
            String _uuid,
            String _name,
            String _description,
            SensorType _sensorType)
        {
            id = _id;
            uuid = _uuid;
            name = _name;
            description = _description;
            sensorType = _sensorType;
        }
    }

    public class SensorList
    {
        [JsonProperty("sensors")]
        public List<Sensor> sensors { get; set; }

        public int count()
        {
            return sensors.Count;
        }
    }


}
