using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EnvSensingXamApp.Models
{
    public class SensorReading
    {
        [JsonProperty("sensor")]
        public Sensor sensor { get; set; }

        [JsonProperty("sensor_value")]
        public long sensorValue { get; set; }

        public SensorReading(Sensor _sensor, int _value)
        {
            sensor = _sensor;
            sensorValue = _value;
        }

        public double getFormattedSensorValue()
        {
            return sensorValue * Math.Pow(10,sensor.sensorType.pow10multi);
        }

    }

    public class SensorReadingList
    {
        [JsonProperty("sensor_readings")]
        public List<SensorReading> sensorReadings { get; set; }
    }

}
