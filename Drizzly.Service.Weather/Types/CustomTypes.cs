using System.Collections.Generic;
using Drizzly.Service.Weather.Providers;

namespace Drizzly.Service.Weather.Types
{
    public class CustomTypes
    {
        
        public class Temperature
        {

            public double Min;
            public double Max;
            public double ?Observed;
            public string Units;
            
            public Temperature(double min, double max, double ?observed, TemperatureUnits units)
            {
                Min = min;
                Max = max;
                Observed = observed;
                Units = units.ToString();
            }
            
        }
        
        public class WindSpeed
        {
            
            public double ?Observed;
            public double ?ObservedGust;
            public WindSpeedUnits Units;
            
            public WindSpeed(double ?observed, WindSpeedUnits units)
            {
                Observed = observed;
                Units = units;
            }
            
        }

        public class WindDirection
        {

            public float Direction;

            public WindDirection(float direction)
            {
                Direction = direction;
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
        
    }
}