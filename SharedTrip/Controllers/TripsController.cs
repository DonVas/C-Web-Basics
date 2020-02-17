using System;
using System.Collections.Generic;
using System.Text;
using SharedTrip.Services;
using SharedTrip.ViewModels;
using SIS.HTTP;
using SIS.MvcFramework;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        [HttpGet("/Trips/Add")]
        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost("/Trips/Add")]
        public HttpResponse Add( AddInputModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.tripsService.Add(input);
            return this.View();
        }

        [HttpGet("/Trips/All")]
        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = new TripsAllModel()
            {
                Trips = this.tripsService.GetAll(x => new TripModelView()
                {  Id = x.Id,
                   StartPoint = x.StartPoint,
                   EndPoint = x.EndPoint,
                   DepartureTime = x.DepartureTime,
                   Seats = x.Seats
                }),
            };
            return this.View(viewModel);
        }

        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.tripsService.GetDetails(tripId);
            return this.View(viewModel);
        }

        [HttpGet("/Trips/AddUserToTrip")]
        public HttpResponse AddUserToTrip(string tripId,string userId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (!this.tripsService.AddUserToTrip(tripId, userId))
            {
                return this.Redirect(@$"/Trips/Details?tripId={tripId}");
            }

            return this.Redirect("/Trips/All");
        }
    }
}
