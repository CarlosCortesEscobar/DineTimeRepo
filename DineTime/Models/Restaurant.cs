using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DineTime.Models
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            Reservations = new HashSet<Reservation>();
        }
        [Key]
        public int RestaurantId { get; set; }
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
        public int SeatsAvailable { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
