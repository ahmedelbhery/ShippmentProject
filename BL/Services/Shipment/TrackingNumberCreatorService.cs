using BL.Contracts.Shipment;
using BL.Dtos;

namespace BL.Services.Shipment
{
    public class TrackingNumberCreatorService : ITrackingNumberCreator
    {
        public string Create()
        {
            var random = new Random();
            var randomPart = random.Next(100000, 999999); 
            var datePart = DateTime.Now.ToString("yyyyMMdd"); 
            return $"TRK-{datePart}-{randomPart}";
        }
    }
}
