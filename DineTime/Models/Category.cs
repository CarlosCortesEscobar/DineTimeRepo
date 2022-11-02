using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DineTime.Models
{
    public partial class Category
    {
        public Category()
        {
            Restaurants = new HashSet<Restaurant>();
        }
        [Key]
        public int CategoryId { get; set; }
        public string Category1 { get; set; } = null!;

        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}
