using System;
using System.Collections.Generic;
using SharedTrip.Models;
using SharedTrip.ViewModels;
using SIS.HTTP;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        IEnumerable<T> GetAll<T>(Func<Trip, T> selectFunc);

        void Add(AddInputModel input);

        TripModelViewOne GetDetails(string id);

        bool AddUserToTrip(string tripId,string userId);
    }
}
