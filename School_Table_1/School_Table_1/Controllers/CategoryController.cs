using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_Table_1.Context;
using School_Table_1.Entities;
using School_Table_1.Dtos;

namespace School_Table_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public ActionResult CreateCategory(CategoryDTO model)
        {
            Category category = new()
            {
                CategoryName = model.CategoryName,
                CategoryDescription = model.CategoryDescription,
            };//maplemek
            _context.Categories.Add(category);
            if (_context.SaveChanges() > 0)
            {
                return Ok();
            }
            return BadRequest();
        }


        [HttpDelete("{categoryId}")]
        public ActionResult DeleteCategory([FromRoute] Guid categoryId)
        {
            var category = _context.Categories.Find(categoryId);
            if (category != null)
            {
                _context.Categories.Remove(category);
                if (_context.SaveChanges() > 0)
                {
                    return Ok();
                }
            }
            return BadRequest();

        }
        [HttpGet]
        public ActionResult GetAllCategory()
        {
            List<Category> categories = _context.Categories.ToList();
            if (categories is not null)
            {
                return Ok(categories);
            }
            return NotFound();
        }

        

        [HttpPut("{categoryId}")]
        public ActionResult UpdateCategory([FromRoute]Guid categoryId, CategoryDTO model)
        {
            var category = _context.Categories.Find(categoryId);
            if (category is not null)
            { 
                category.CategoryDescription = model.CategoryDescription;
                category.CategoryName = model.CategoryName;
                if(_context.SaveChanges() > 0) {
                    return Ok(model);
                }
               
            }
            return NotFound();
        }
    }
}
