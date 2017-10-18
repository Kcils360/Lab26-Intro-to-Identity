using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab28LoginAuth.Models;

namespace Lab28LoginAuth.Controllers
{
    public class RecipeModelsController : Controller
    {
        private readonly Lab28LoginAuthContext _context;

        public RecipeModelsController(Lab28LoginAuthContext context)
        {
            _context = context;
        }

        // GET: RecipeModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.RecipeModel.ToListAsync());
        }

        // GET: RecipeModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeModel = await _context.RecipeModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (recipeModel == null)
            {
                return NotFound();
            }

            return View(recipeModel);
        }

        // GET: RecipeModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RecipeModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Dish,Category,Ingredients,Recipe,IsPublished")] RecipeModel recipeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recipeModel);
        }

        // GET: RecipeModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeModel = await _context.RecipeModel.SingleOrDefaultAsync(m => m.ID == id);
            if (recipeModel == null)
            {
                return NotFound();
            }
            return View(recipeModel);
        }

        // POST: RecipeModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Dish,Category,Ingredients,Recipe,IsPublished")] RecipeModel recipeModel)
        {
            if (id != recipeModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeModelExists(recipeModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(recipeModel);
        }

        // GET: RecipeModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeModel = await _context.RecipeModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (recipeModel == null)
            {
                return NotFound();
            }

            return View(recipeModel);
        }

        // POST: RecipeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipeModel = await _context.RecipeModel.SingleOrDefaultAsync(m => m.ID == id);
            _context.RecipeModel.Remove(recipeModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeModelExists(int id)
        {
            return _context.RecipeModel.Any(e => e.ID == id);
        }
    }
}
