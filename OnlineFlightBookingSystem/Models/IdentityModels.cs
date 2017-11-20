using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFlightBookingSystem.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {

            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string name { get; set; }
        public string passport { get; set; }
        public string country { get; set; }
        public virtual ICollection<Flight_Booking> Flight_Booking { get; set; }
        
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Airport> Airport { get; set; }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<Flight_Booking> Flight_Booking  { get; set; }
}

    public class Airport
    {
        [Key]
        public string airport_id { get; set; }
        public string country { get; set; }
    }

    public class Flight
    {
        [Key]
        public string flight_id { get; set; }
        public string departure_datetime { get; set; }
        public string arrive_datetime { get; set; }
        public double flight_cost { get; set; }
        public string flight_class { get; set;}
        public Airport arrive { get; set; }
        public Airport origin { get; set; }
    }

    public class Flight_Booking
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int flight_booking_id { get; set; }
        public Flight selected { get; set; }
        public int passenger_number { get; set; }
        public double total_cost { get; set; }
    }

}