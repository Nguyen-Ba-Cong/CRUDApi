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
        public List<NewModel> GetNews();
        public NewModel AddNew(NewModel newModel);
        public NewModel UpdateNew(int id, NewModel newModel);
        public NewModel DeleteNew(int id);
    }
}
