using System.Collections.Generic;

namespace SharedTrip.ViewModels
{
    public class TripsAllModel
    {
        public IEnumerable<TripModelView> Trips { get; set; }
    }
}
