using System;
using Newtonsoft.Json;

namespace EnvSensingXamApp.Models
{
    public class SensorType
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("name")]
        public String name { get; set; }

        [JsonProperty("unit")]
        public String unit { get; set; }

        [JsonProperty("pow10multi")]
        public int pow10multi { get; set; }

        public SensorType(int _id,
            String _name,
            String _unit,
            int _pow10multi)
        {
            id = _id;
            name = _name;
            unit = _unit;
            pow10multi = _pow10multi;
        }

    }
}
