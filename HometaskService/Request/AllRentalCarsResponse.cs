using System.Collections.Generic;

namespace CarRentalService.Request
{
    public class AllRentalCarsResponse
    {
        public List<RentalCarResponse> Cars { get; set; }
    }
}
