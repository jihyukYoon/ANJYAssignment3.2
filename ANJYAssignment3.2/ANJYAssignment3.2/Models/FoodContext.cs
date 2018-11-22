using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ANJYAssignment3._2.Models
{
    public class FoodContext : DbContext
    {
        public FoodContext(DbContextOptions<FoodContext> options)
            : base(options)
        {
        }

        public DbSet<Foods> Foods { get; set; }
    }
}
