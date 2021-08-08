using DesignPattern.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Service.IRepositories
{
    public interface INewRepository
    {
        public New GetNew(int id);
        public List<New> GetNews();
        public New AddNew(New neww);
        public New UpdateNew(int id, New neww);
        public New DeleteNew(int id);
    }
}
