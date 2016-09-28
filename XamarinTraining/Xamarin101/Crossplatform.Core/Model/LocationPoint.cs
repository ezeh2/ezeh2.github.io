namespace Crossplatform.Core.Model
{
    public class LocationPoint
    {
        public LocationPoint(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

    }
}