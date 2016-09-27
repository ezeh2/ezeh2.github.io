using System;
using System.Threading.Tasks;
using Crossplatform.Core.Model;

namespace Crossplatform.Core.Services
{
    public class AReallyGreatService
    {
        private readonly IPositionService _positionServiceService;

        public AReallyGreatService(IPositionService positionServiceService)
        {
            if (positionServiceService == null) throw new ArgumentNullException(nameof(positionServiceService));
            _positionServiceService = positionServiceService;
        }

        public async Task<bool> AreWeThereYetAsync(LocationPoint desiredDestination)
        {
            var currentLocation = await _positionServiceService.GetCurrentPositionAsync();
            var hasDesiredLatitude = Math.Abs(desiredDestination.Latitude - currentLocation.Latitude) < 0.01;
            var hasDesiredLongitude = Math.Abs(desiredDestination.Longitude - currentLocation.Longitude) < 0.01;

            return hasDesiredLongitude && hasDesiredLatitude;
        }

        public async Task<LocationPoint> GetCurrentLocation()
        {
            return await _positionServiceService.GetCurrentPositionAsync();
        }
    }
}