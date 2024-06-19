using Microsoft.AspNetCore.Mvc;
using foodapp.Data;
using foodapp.Models;
using Microsoft.EntityFrameworkCore;
namespace foodapp.Controllers
{
    public class foodapp : Controller
    {
        private readonly MenuContext _context;
        public foodapp(MenuContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            var dishes = from d in _context.Dishes
                         select d;
            if (!string.IsNullOrEmpty(searchString))
            {
                dishes = dishes.Where(d => d.Name.Contains(searchString));
                return View(await dishes.ToListAsync());

            }
            return View(await dishes.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            var dish = await _context.Dishes
                .Include(di => di.DishIngredients)
                .ThenInclude(i => i.ingredient)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (dish == null)
            {
                return NotFound();
            }
            return View(dish);
        }
    }
}
