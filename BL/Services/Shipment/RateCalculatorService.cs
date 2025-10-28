using BL.Contracts.Shipment;
using BL.Dtos;

namespace BL.Services.Shipment
{
    public class RateCalculatorService : IRateCalculator
    {
        public decimal Calculate(ShipmentDto dto)
        {
            return dto.PackageValue;
        }
    }
}
