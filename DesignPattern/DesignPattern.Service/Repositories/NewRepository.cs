using DesignPattern.Database.Entity;
using DesignPattern.Service.IRepositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Service.Repositories
{
    public class NewRepository : BaseRepository<New>, INewRepository
    {
        private readonly DesignPatternDBContext _context;
        public NewRepository(DesignPatternDBContext context) : base(context)
        {
            _context = context;
        }

        public New AddNew(string userId, New neww)
        {
            try
            {
                var idToFind = Convert.ToInt32(userId);
                var user = _context.Users.FirstOrDefault(u => u.Id == idToFind);
                var newToAdd = new New();
                newToAdd.Title = neww.Title;
                newToAdd.Content = neww.Content;
                newToAdd.Image = neww.Image;
                newToAdd.Description = neww.Description;
                newToAdd.Users = user;
                _context.News.Add(newToAdd);
                _context.SaveChanges();
                return newToAdd;

            }
            catch (Exception e)
            {
                Console.WriteLine(JsonConvert.SerializeObject(e));
                return null;
            }
        }

        public void DeleteNew(string userId, New neww)
        {
            try
            {
                var newDel = _context.News.Include(n => n.Users).FirstOrDefault(n => n.Id == neww.Id);
                var idInt = Convert.ToInt32(userId);
                if (newDel.Users.Id == idInt)
                {
                    _context.News.Remove(newDel);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(JsonConvert.SerializeObject(e));
            }
        }

        public void UpdateNew(string userId, New neww)
        {
            try
            {
                var newUpdate = _context.News.Include(n => n.Users).FirstOrDefault(n => n.Id == neww.Id);
                var idInt = Convert.ToInt32(userId);
                if (newUpdate.Users.Id == idInt)
                {
                    newUpdate.Title = neww.Title;
                    newUpdate.Content = neww.Content;
                    newUpdate.Image = neww.Image;
                    newUpdate.Description = neww.Description;
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(JsonConvert.SerializeObject(e));
            }
        }
    }
}
