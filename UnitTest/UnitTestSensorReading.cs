using EnvSensingXamApp.Models;
using NUnit.Framework;


namespace UnitTestSensorReading
{
    public class Tests
    {
        SensorType sensorType0; 
        SensorType sensorTypeP2; 
        SensorType sensorTypeM2; 

        Sensor sensor1; 
        Sensor sensor2; 
        Sensor sensor3;

        [SetUp]
        public void Setup()
        {
             sensorType0 = new SensorType(1, "sensor type  0", "unit 0", 0);
             sensorTypeP2 = new SensorType(1, "sensor type  2", "unit 2", 2);
             sensorTypeM2 = new SensorType(1, "sensor type -2", "unit -2", -2);

             sensor1 = new Sensor(1, "123-001", "sensor 1", "description 1", sensorType0);
             sensor2 = new Sensor(2, "123-002", "sensor 2", "description 2", sensorTypeP2);
             sensor3 = new Sensor(3, "123-003", "sensor 3", "description 3", sensorTypeM2);

        }

        [Test]
        public void TestSensorReadingPOW0()
        {  
            SensorReading sensorReading = new SensorReading(sensor1, 100);
            Assert.AreEqual(sensorReading.getFormattedSensorValue(), 100.0);
        }

        [Test]
        public void TestSensorReadinPOWP2()
        {
            SensorReading sensorReading = new SensorReading(sensor2, 100);
            Assert.AreEqual(sensorReading.getFormattedSensorValue(), 10000.0);
        }

        [Test]
        public void TestSensorReadingPOWM2()
        {
            SensorReading sensorReading = new SensorReading(sensor3, 100);
            Assert.AreEqual(sensorReading.getFormattedSensorValue(), 1.0);
        }

        [Test]
        public void TestSensorReadingPOWM2PI()
        {
            SensorReading sensorReading = new SensorReading(sensor3, 314);
            Assert.AreEqual(sensorReading.getFormattedSensorValue(), 3.14);
        }

    }
}