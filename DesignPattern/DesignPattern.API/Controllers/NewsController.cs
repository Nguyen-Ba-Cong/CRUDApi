using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DesignPattern.Service.IApiServices;
using DesignPattern.Service.Models;

namespace DesignPattern.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewService _newSerVice;

        public NewsController(INewService newSerVice)
        {
            _newSerVice = newSerVice;
        }

        // GET: api/News
        [HttpGet]
        public List<NewModel> GetNews(int offset = 0, int limit = 10)
        {
            return _newSerVice.GetNews(offset, limit);
        }

        // get: api/news/5
        [HttpGet("{id}")]
        public NewModel GetNew(int id)
        {
            return _newSerVice.GetNew(id);
        }

        // PUT: api/News/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public NewModel PutNew(NewModel newModel)
        {
            var userId = HttpContext.Session.GetString("UserId");
            return _newSerVice.UpdateNew(userId, newModel);
        }

        // POST: api/News
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public NewModel PostNew(NewModel newModel)
        {
            var userId = HttpContext.Session.GetString("UserId");
            var newResult = _newSerVice.AddNew(userId, newModel);
            return newResult;
        }

        // DELETE: api/News/5
        [HttpDelete("{id}")]
        public NewModel DeleteNew(NewModel newModel)
        {
            string userId = HttpContext.Session.GetString("UserId");
            return _newSerVice.DeleteNew(userId, newModel);
        }

        //private bool NewExists(int id)
        //{
        //    return _context.News.Any(e => e.Id == id);
        //}
    }
}
