using DesignPattern.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Service.IRepositories
{
    public interface INewRepository : IBaseRepository<New>
    {
        public New AddNew(string userId, New neww);
        public void DeleteNew(string userId, New neww);
        public void UpdateNew(string userId, New neww);
    }
}
