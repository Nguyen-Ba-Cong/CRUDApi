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
        public List<NewModel> GetNews()
        {
            return _newSerVice.GetNews();
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
        public NewModel PutNew(int id, NewModel newModel)
        {
            return _newSerVice.UpdateNew(id, newModel);
        }

        // POST: api/News
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public NewModel PostNew(NewModel newModel)
        {
            return _newSerVice.AddNew(newModel);
        }

        // DELETE: api/News/5
        [HttpDelete("{id}")]
        public NewModel DeleteNew(int id)
        {
            return _newSerVice.DeleteNew(id);
        }

        //private bool NewExists(int id)
        //{
        //    return _context.News.Any(e => e.Id == id);
        //}
    }
}
