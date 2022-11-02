using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DineTime.Models
{
    public partial class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string? Comments { get; set; }
    }
}
