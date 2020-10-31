using System;
namespace EnvSensingXamApp.Models
{
    public class SensorReadingDisplay
    {
        public String displayValue { get; set; }
        public String displayDateTime { get; set; }

        public SensorReadingDisplay(SensorReading val)
        {
            displayValue = val.getFormattedSensorValueWithUnit();
            displayDateTime = val.dateTime.ToString();
        }
    }
}
