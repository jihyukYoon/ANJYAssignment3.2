using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ANJYAssignment3._2.Models
{
    public class Foods
    {
        [Key]
        public int Food_id { get; set; }
        public string FoodName { get; set; }
        public string description { get; set; }
        public int price { get; set; }

    }
}
