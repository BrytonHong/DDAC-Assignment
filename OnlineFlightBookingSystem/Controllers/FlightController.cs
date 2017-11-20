using Microsoft.AspNet.Identity;
using OnlineFlightBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineFlightBookingSystem.Controllers
{
    public class FlightController : Controller
    {
        ApplicationDbContext database = new ApplicationDbContext();
        [HttpGet]
        // GET: Flight
        public ActionResult SearchFlight()
        {
            return View(new List<Flight>());
        }

        [HttpPost]
        public ActionResult SearchFlight(String origin, String arrive)
        {
            var FlightDetails = database.Flight.Include("origin").Include("arrive").Where(x => x.origin.country.Contains(origin) && x.arrive.country.Contains(arrive)).ToList();
            return View(FlightDetails);
        }

        public ActionResult Booking(String id)
        {
            var FlightDetails = database.Flight.Include("origin").Include("arrive").Where(x => x.flight_id == id).First();
            return View(FlightDetails);
        }

        [HttpPost]
        public ActionResult Booking(String flightId, int number)
        {
            string userId = User.Identity.GetUserId();
            
            Flight FlightID = database.Flight.Find(flightId);

            Flight_Booking flightBooking = new Flight_Booking();
            flightBooking.selected = FlightID;

            double totalCost = number * FlightID.flight_cost;
            flightBooking.total_cost = totalCost;

            int no_passenger = number;
            flightBooking.passenger_number = no_passenger;

            database.Users.Find(userId).Flight_Booking.Add(flightBooking);//Saving for User

            database.SaveChanges();

            return RedirectToAction("SearchFlight");
        }
    }
}