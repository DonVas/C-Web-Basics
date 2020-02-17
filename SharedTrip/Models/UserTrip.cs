using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SharedTrip.Models
{
    public class UserTrip
    {

        //•	Has UserId – a string
        //•	Has User – a User object
        //•	Has TripId– a string
        //•	Has Trip – a Trip object

        [ForeignKey(nameof(User)), Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string UserId { get; set; }

        public User User { get; set; }

        [ForeignKey(nameof(Trip)), Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string TripId { get; set; }
            
        public Trip Trip { get; set; }
    }
}
