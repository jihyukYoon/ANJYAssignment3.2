using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ANJYAssignment3._2.Models;

namespace ANJYAssignment3._2.Controllers
{
    public class FoodsController : Controller
    {
        private readonly FoodContext _context;

        public FoodsController(FoodContext context)
        {
            _context = context;

            if (_context.Foods.Count() == 0)
            {
                _context.Foods.Add(new Foods
                {
                    Food_id = 1,
                    FoodName = "CLUB STEAK",
                    description = "The tasties part of the sirloin, the center cut. 13oz broiled",
                    price = 20
                });
                _context.Foods.Add(new Foods
                {
                    Food_id = 2,
                    FoodName = "PORTER HOUSE",
                    description = "The perfect combination. This 26 oz steak.",
                    price = 40
                });
                _context.Foods.Add(new Foods
                {
                    Food_id = 3,
                    FoodName = "BONE-IN RIB EYE",
                    description = "24 ounces of the juiciest, tastiest beef around",
                    price = 32
                });
                _context.SaveChanges();
            }
        }
        //Foods[] foods = new Foods[]
        //{
        //    new Foods { Food_id=1,FoodName="CLUB STEAK",
        //                description ="The tasties part of the sirloin, the center cut. 13oz broiled",price=20},
        //    new Foods { Food_id=2,FoodName="PORTER HOUSE",
        //                description ="The perfect combination. This 26 oz steak.",price=40},
        //    new Foods { Food_id=3,FoodName="BONE-IN RIB EYE",
        //                description ="24 ounces of the juiciest, tastiest beef around",price=32}
        //};
        [Route("api/foods")]
        public ActionResult<List<Foods>> GetAllFoods()
        {
            return _context.Foods.ToList();
        }
        [Route("api/foods/{Food_id}")]
        public ActionResult<Foods> GetFoodById(int Food_id)
        {
            var food = _context.Foods.Find(Food_id);
            if (food == null)
            {
                return NotFound();
            }
            return Ok(food);
        }
        [HttpDelete("{Food_id}")]
        [Route("api/foods/delete/{Food_id}")]
        public ActionResult<List<Foods>> Delete(int Food_id)
        {
            var food = _context.Foods.Find(Food_id);
            if (food == null)
            {
                return NotFound();
            }

            _context.Foods.Remove(food);
            _context.SaveChanges();
            return _context.Foods.ToList();
        }
        [HttpPost]
        [Route("api/foods/Create")]
        public ActionResult Create(Foods food)
        {
            _context.Foods.Add(food);
            _context.SaveChanges();

            return CreatedAtRoute("GetFood", new { id = food.Food_id }, food);
        }
    }
}