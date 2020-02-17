using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace SharedTrip.Models
{
    public class Trip
    {

        //•	Has an Id – a string, Primary Key
        //•	Has a StartPoint – a string (required)
        //•	Has a EndPoint – a string (required)
        //•	Has a DepartureTime – a datetime(required) (use format: "dd.MM.yyyy HH:mm")
        //•	Has a Seats – an integer with min value 2 and max value 6 (required)
        //•	Has a Description – a string with max length 80 (required)
        //•	Has a ImagePath – a string
        //•	Has UserTrips collection – a UserTrip type

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public string StartPoint { get; set; }

        [Required]
        public string EndPoint { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        [MinLength(2),MaxLength(6)]
        public int Seats { get; set; }

        [MaxLength(80)]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        public List<UserTrip> UserTrips { get; set; }
    }
}
