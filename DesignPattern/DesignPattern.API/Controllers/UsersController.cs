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
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users?limit=10&offset=1
        [HttpGet]
        public List<UserModel> GetUsers(int limit = 10, int offset = 0)
        {
            var users = _userService.GetUsers(offset, limit);
            return users;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public UserModel GetUser(int id)
        {
            var user = _userService.GetUser(id);
            return user;
        }
        // GET: api/Users/5/News
        [HttpGet("{id}/News")]
        public List<NewModel> GetNewByUserId(int id)
        {
            var news = _userService.GetNewByUserId(id);
            return news;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public UserModel PutUser(UserModel user)
        {
            var userUpdate = _userService.UpdateUser(user);
            return userUpdate;
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public UserModel PostUser(UserModel user)
        {
            var userAdd = _userService.AddUser(user);
            return userAdd;

        }

        // DELETE: api/Users/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public UserModel DeleteUser(int id, UserModel user)
        {
            var userDel = _userService.DeleteUser(id, user);
            return userDel;
        }

        //private bool UserExists(int id)
        //{
        //    return _context.Users.Any(e => e.Id == id);
        //}
    }
}
