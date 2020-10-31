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

        [JsonProperty("date_time")]
        public DateTime dateTime { get; set; }

        public SensorReading(Sensor _sensor, int _value, DateTime _date_time)
        {
            sensor = _sensor;
            sensorValue = _value;
            dateTime = _date_time;
        }

        public double getFormattedSensorValue()
        {
            return sensorValue * Math.Pow(10,sensor.sensorType.pow10multi);
        }

        public String getFormattedSensorValueWithUnit()
        {
            return (sensorValue * Math.Pow(10, sensor.sensorType.pow10multi)).ToString() + " " + sensor.sensorType.unit;
        }
    }

    public class SensorReadingList
    {
        [JsonProperty("sensor_readings")]
        public List<SensorReading> sensorReadings { get; set; }

        public int count()
        {
            return sensorReadings.Count;
        }
    }

}
