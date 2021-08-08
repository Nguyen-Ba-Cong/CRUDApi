using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DesignPattern.Service.IApiServices;
using DesignPattern.Service.Models;
using Microsoft.AspNetCore.Authorization;

namespace DesignPattern.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Categories
        [HttpGet]
        public List<CategoryModel> GetCategories(int limit = 10, int offset = 0)
        {
            return _categoryService.GetCategories(offset, limit);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public CategoryModel GetCategory(int id)
        {
            var category = _categoryService.GetCategory(id);
            return category;
        }
        [HttpGet("{id}/News")]
        public List<NewModel> GetNewByCategoryId(int id)
        {
            var news = _categoryService.GetNewByCategoryId(id);
            return news;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public CategoryModel PutCategory(int id, CategoryModel category)
        {
            return _categoryService.UpdateCategory(id, category);
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public CategoryModel PostCategory(CategoryModel category)
        {
            return _categoryService.AddCategory(category);
        }
        [Authorize(Roles = "Admin")]

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public CategoryModel DeleteCategory(int id, CategoryModel categoryModel)
        {
            return _categoryService.DeleteCategory(id, categoryModel);
        }

    }
}
