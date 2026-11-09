using TransitApplication.Models;

namespace TransitApplication.Services
{
    public static class GeoCalculator
    {
        public static double DegreesToRadians(double degrees)
        {

            double radians = degrees * (Math.PI / 180);
            return radians;
        }

        public static double CalculateDistance(BusStop stop1, BusStop stop2)
        {
            double earthRadius = 6371;

            double lat1 = DegreesToRadians(stop1.Latitude);
            double lon1 = DegreesToRadians(stop1.Longitude);
            double lat2 = DegreesToRadians(stop2.Latitude);
            double lon2 = DegreesToRadians(stop2.Longitude);

            double deltaLat = lat2 - lat1;
            double deltaLon = lon2 - lon1;

            double a = Math.Pow(Math.Sin(deltaLat /2), 2) + (Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow(Math.Sin(deltaLon/2),2));
            a = Math.Clamp(a, 0.0, 1.0); //to account for floating point rounding
            double d = 2 * earthRadius * Math.Asin(Math.Sqrt(a));

            return d;
        }
    }
}