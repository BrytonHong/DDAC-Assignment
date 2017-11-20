using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OnlineFlightBookingSystem.Models
{
    public class FlightViewModel
    {
        [Display(Name = "Booking ID")]
        public string flight_booking_id { get; set; }

        [Display(Name = "Flight ID")]
        public string flight_id { get; set; }

        [Display(Name = "Origin")]
        public Airport origin { get; set; }

        [Display(Name = "Departure Date and Time")]
        public string departure_datetime { get; set; }

        [Display(Name = "Destination")]
        public Airport arrive { get; set; }

        [Display(Name = "Arrival Date and Time")]
        public string arrive_datetime { get; set; }

        [Display(Name = "Class Type")]
        public string flight_class { get; set; }

        [Display(Name = "Number of Passenger")]
        public string passenger_number { get; set; }

        [Display(Name = "Total Cost")]
        public string total_cost { get; set; }
    }
}