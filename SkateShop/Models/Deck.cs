using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkateShop.Models
{
    public class Deck
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public string img { get; set; }
        public string info { get; set; }
        public bool sale { get; set; }
    }
}