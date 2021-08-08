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
    public class NewRepository : INewRepository
    {
        private readonly DesignPatternDBContext _context;
        public NewRepository(DesignPatternDBContext context)
        {
            _context = context;
        }
        public New AddNew(New neww)
        {
            try
            {
                _context.News.Add(neww);
                _context.SaveChanges();
                return neww;
            }
            catch (Exception e)
            {
                Console.WriteLine(JsonConvert.SerializeObject(e));
            }
            return null;
        }

        public New DeleteNew(int id)
        {
            try
            {
                var newDel = GetNew(id);
                _context.Remove(newDel);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(JsonConvert.SerializeObject(e));
            }
            return null;
        }

        public New GetNew(int id)
        {
            try
            {
                var neww = _context.News.Include(n => n.Categories).ThenInclude(c=>c.News).FirstOrDefault(n => n.Id == id);
                return neww;
            }
            catch (Exception e)
            {
                Console.WriteLine(JsonConvert.SerializeObject(e));
            }
            return null;
        }

        public List<New> GetNews()
        {
            try
            {
                var news = _context.News.ToList();
                return news;
            }
            catch (Exception e)
            {
                Console.WriteLine(JsonConvert.SerializeObject(e));
            }
            return null;
        }

        public New UpdateNew(int id, New neww)
        {
            try
            {
                if (neww.Id != id)
                {
                    Console.WriteLine("Id Not Match");
                    return null;
                }
                else
                {
                    var newUpdate = GetNew(id);
                    newUpdate.Title = neww.Title;
                    newUpdate.Image = neww.Image;
                    newUpdate.Content = neww.Content;
                    newUpdate.Categories = neww.Categories;
                    newUpdate.Description = neww.Description;
                    _context.SaveChanges();
                    return newUpdate;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(JsonConvert.SerializeObject(e));
            }
            return null;
        }
    }
}
