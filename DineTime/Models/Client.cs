using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DineTime.Models
{
    public partial class Client
    {
        public Client()
        {
            Reservations = new HashSet<Reservation>();
        }
        [Key]
        public int ClientId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
