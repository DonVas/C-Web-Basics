using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using SharedTrip.Models;
using SharedTrip.ViewModels;
using SIS.MvcFramework;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        
        public void Add(AddInputModel input)
        {
            var trip = new Trip()
            {
                StartPoint = input.StartPoint,
                //DepartureTime = DateTime.ParseExact(input.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                DepartureTime = DateTime.ParseExact(input.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                Description = input.Description,
                EndPoint = input.EndPoint,
                ImagePath = input.ImagePath,
                Seats = input.Seats,
            };
            this.db.Trips.Add(trip); 
            this.db.SaveChanges();
        }

        public IEnumerable<T> GetAll<T>(Func<Trip, T> selectFunc)
        {
            var trips = this.db.Trips.Select(selectFunc).ToList();
               return trips;
        }

        public TripModelViewOne GetDetails(string tripId)
        {

            var trip = this.db.Trips.Where(x => x.Id == tripId)
                .Select(x => new TripModelViewOne()
                {
                   Id = x.Id,
                   EndPoint = x.EndPoint,
                   DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                   StartPoint = x.StartPoint,
                   ImagePath = x.ImagePath,
                   Seats = x.Seats,
                   Description = x.Description

                }).FirstOrDefault();
            return trip;
        }

        public bool AddUserToTrip(string tripId, string userId)
        {
           this.db.Trips.Where(x => x.Id == tripId).FirstOrDefault().Seats--;

            var user = this.db.Users.Where(x => x.Id == userId)
                .Select(x => new User()
                {
                    Id = x.Id,                    
                }).FirstOrDefault();

            var userTripExist = this.db.UserTrips.Where(x => x.TripId == tripId).FirstOrDefault();

            var userTrip = new UserTrip();

            if (userTripExist != null)
            {
                if (userTripExist.UserId == user.Id)
                {
                    return false;
                }
                userTrip.TripId = tripId;
                userTrip.UserId = userId;
            }
            else
            {
                userTrip.TripId = tripId;
                userTrip.UserId = userId;
            }

            this.db.UserTrips.Add(userTrip);
            this.db.SaveChanges();
            return true;
        }   
    }
}
