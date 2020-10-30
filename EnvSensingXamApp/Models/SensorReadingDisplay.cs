using System;
namespace EnvSensingXamApp.Models
{
    public class SensorReadingDisplay
    {
        public String displayValue { get; set; }

        public SensorReadingDisplay(String val)
        {
            displayValue = val;
        }

        public SensorReadingDisplay(SensorReading val)
        {
            displayValue = val.getFormattedSensorValueWithUnit();
        }
    }
}
