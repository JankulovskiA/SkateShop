using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkateShop.Models
{
    public class Complete
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public string info { get; set; }
        public string img { get; set; }
        public Deck deck { get; set; }
        public Truck truck { get; set; }
        public Wheel wheel { get; set; }

    }
}