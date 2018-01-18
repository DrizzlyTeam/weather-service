using System;
using System.Collections.Generic;
using Drizzly.Service.Weather.Providers;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;

namespace Drizzly.Service.Weather.Types
{
    public class CustomTypes
    {
        public class Infos
        {
            public string DataType;
            public Locations Location;
            public Sun Sun;

            public Infos()
            {
            }

            public Infos(string dataType, Locations location, Sun sun)
            {
                DataType = dataType;
                Location = location;
                Sun = sun;
            }
        }

        public class Locations
        {
            public double Latitude;
            public double Longitude;
            public string Name;
            public string Country;

            public Locations(double latitude, double longitude, string name, string country)
            {
                Latitude = latitude;
                Longitude = longitude;
                Name = name;
                Country = country;
            }
        }

        public class Sun
        {
            public double Sunrise;
            public double Sunset;

            public Sun(double sunrise, double sunset)
            {
                Sunrise = sunrise;
                Sunset = sunset;
            }
        }

        public class Temperature
        {
            public double Min;
            public double Max;
            public double? Observed;
            public string Unit;

            public Temperature(double min, double max, double? observed, TemperatureUnits unit)
            {
                Min = min;
                Max = max;
                Observed = observed;
                Unit = unit.ToString();
            }
        }

        public class Winds
        {
            public WindSpeed Speed;
            public int Direction;

            public Winds(WindSpeed speed, int direction)
            {
                Speed = speed;
                Direction = direction;
            }
        }

        public class WindSpeed
        {
            public double? Observed;
            public double? ObservedGust;
            public string Unit;

            public WindSpeed(double? observed, double? observedGust, WindSpeedUnits unit)
            {
                Observed = observed;
                ObservedGust = observedGust;
                Unit = unit.ToString();
            }
        }

        public class Precipitations
        {
            public bool Raining => Rain != null;
            public double? Rain;
            
            public bool Snowing => Snow != null;
            public double? Snow;

            public Precipitations(double? rain, double? snow)
            {
                Rain = rain;
                Snow = snow;
            }
        }

        public enum TemperatureUnits
        {
            Celsius,
            Fahrenheit,
            Kelvin
        }

        public enum WindSpeedUnits
        {
            KilometersPerHour,
            MilesPerHour,
            MetersPerSeconds
        }

        public enum DataTypes
        {
            Current,
            Forecast
        }
    }
}