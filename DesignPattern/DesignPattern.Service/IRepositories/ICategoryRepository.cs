using DesignPattern.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Service.IRepositories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        //public List<Category> GetCategories();
        //public Category GetCategory(int id);
        //public Category AddCategory(Category category);
        //public Category UpdateCategory(int id, Category category);
        //public Category DeleteCategory(int id);
        public List<New> GetNewByCategoryId(int id);
    }
}
