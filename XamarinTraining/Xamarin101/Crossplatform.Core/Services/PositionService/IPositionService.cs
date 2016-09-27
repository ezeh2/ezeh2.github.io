using System.Threading.Tasks;
using Crossplatform.Core.Model;

namespace Crossplatform.Core.Services
{
    public interface IPositionService
    {
        Task<LocationPoint> GetCurrentPositionAsync();
    }
}