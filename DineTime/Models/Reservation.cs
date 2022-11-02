using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DineTime.Models
{
    public partial class Reservation
    {
        [Key]
        public int ReservationId { get; set; }
        public int RestaurantId { get; set; }
        public int ClientId { get; set; }
        public TimeSpan? ReservationTime { get; set; }
        public DateTime ReservationDate { get; set; }
        public int NumberInParty { get; set; }

        public virtual Client? Client { get; set; }
        public virtual Restaurant? Restaurant { get; set; }
    }
}
