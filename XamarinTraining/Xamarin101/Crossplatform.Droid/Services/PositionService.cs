using System;
using System.Threading.Tasks;
using Crossplatform.Core.Model;
using Crossplatform.Core.Services;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace Crossplatform.Droid.Services
{
public class PositionService:IPositionService
{
    public async Task<LocationPoint> GetCurrentPositionAsync()
    {
        try
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 1000; // meters
            var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
            return new LocationPoint(position.Latitude, position.Longitude);
        }
        catch (GeolocationException ex)
        {
            Console.WriteLine(ex);
            return new LocationPoint(0D,0D);
        }

    }
}
}