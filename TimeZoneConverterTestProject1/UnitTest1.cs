using IANAToWindosTimezoneConverter1.Models;
using IANAToWindosTimezoneConverter1.Services;
using NUnit.Framework;
using System;

namespace TimeZoneConverterTestProject1
{
    public class Tests
    {
        private ConverterService converter;
        
        [SetUp]
        public void Setup()
        {
            converter = new ConverterService();
        }

        [Test]
        public void TestIanaToWindowsConvertionPosisitve()
        {
            var data = new Request { Name = "America/New_York" };
            Assert.AreEqual("Eastern Standard Time", converter.ConvertFromIanaTz(data).Result);
        }

        [Test]
        public void TestIanaToWindowsConvertionNegative()
        {
            var data = new Request { Name = "America/New_York1" };
            Assert.AreEqual($"Unable to find the {data.Name} zone in the registry, or it has been corrupted", converter.ConvertFromIanaTz(data).Result);
        }

        [Test]
        public void TestWindowsToIanaConvertionPositive()
        {
            var data = new Request { Name = "Eastern Standard Time" };
            Assert.AreEqual("America/New_York",converter.ConvertFromWindosTz(data).Result);
        }

        [Test]
        public void TestWindowsToIanaConvertionNegative()
        {
            var data = new Request { Name = "Eastern Standard Time1" };
            Assert.AreEqual($"Unable to find the {data.Name} zone in the registry, or it has been corrupted", converter.ConvertFromWindosTz(data).Result);
        }

        [Test]
        public void TestDateTimeBetweenTimeZonesConversionPositive()
        {
            var data = new DateTimeRequest
            {
                Date = new DateTime(2020, 2, 12, 19, 17, 52),
                TimeZoneNameFrom = "America/New_York",
                TimeZoneNameTo = "Europe/Minsk"
            };
            Assert.AreEqual("2/13/2020 3:17:52 AM", converter.ConvertDateTime(data).Result);
        }

        [Test]
        public void TestDateTimeBetweenTimeZonesConversionNegative1()
        {
            var data = new DateTimeRequest
            {
                Date = new DateTime(2020, 2, 12, 19, 17, 52),
                TimeZoneNameFrom = "America/New_York1",
                TimeZoneNameTo = "Europe/Minsk"
            };
            Assert.AreEqual($"Unable TimeZoneNot to find the {data.TimeZoneNameFrom} or {data.TimeZoneNameTo} zone in the registry, or it has been corrupted.", converter.ConvertDateTime(data).Result);
        }

        [Test]
        public void TestDateTimeBetweenTimeZonesConversionNegative2()
        {
            var data = new DateTimeRequest
            {
                Date = new DateTime(2020, 2, 12, 19, 17, 52),
                TimeZoneNameFrom = "America/New_York",
                TimeZoneNameTo = "Europe/Minsk1"
            };
            Assert.AreEqual($"Unable TimeZoneNot to find the {data.TimeZoneNameFrom} or {data.TimeZoneNameTo} zone in the registry, or it has been corrupted.", converter.ConvertDateTime(data).Result);
        }

        [Test]
        public void TestDateTimeBetweenTimeZonesConversionNegative3()
        {
            var data = new DateTimeRequest
            {
                Date = new DateTime(2020, 2, 12, 19, 17, 52),
                TimeZoneNameFrom = "America/New_York1",
                TimeZoneNameTo = "Europe/Minsk1"
            };
            Assert.AreEqual($"Unable TimeZoneNot to find the {data.TimeZoneNameFrom} or {data.TimeZoneNameTo} zone in the registry, or it has been corrupted.", converter.ConvertDateTime(data).Result);
        }
    }
}