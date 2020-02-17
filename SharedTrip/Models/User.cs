using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SIS.MvcFramework;

namespace SharedTrip.Models
{
    public class User : IdentityUser<string>
    {
        public User()
            : base()
        {
            this.UserTrips = new List<UserTrip>();
            this.Id = Guid.NewGuid().ToString();
        }

        public List<UserTrip> UserTrips { get; set; }
    }
}
