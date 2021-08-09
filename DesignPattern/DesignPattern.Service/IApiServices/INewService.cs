using DesignPattern.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Service.IApiServices
{
    public interface INewService
    {
        public NewModel GetNew(int id);
        public List<NewModel> GetNews(int offset, int limit);
        public NewModel AddNew(string userId, NewModel newModel);
        public NewModel UpdateNew(string userId, NewModel newModel);
        public NewModel DeleteNew(string userId, NewModel newModel);
    }
}
