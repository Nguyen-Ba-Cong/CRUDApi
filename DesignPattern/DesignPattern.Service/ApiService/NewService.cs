using AutoMapper;
using DesignPattern.Database.Entity;
using DesignPattern.Service.IApiServices;
using DesignPattern.Service.IRepositories;
using DesignPattern.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Service.ApiService
{
    public class NewService : INewService
    {
        private readonly INewRepository _newRepository;
        private readonly IMapper _mapper;
        public NewService(INewRepository newRepository, IMapper mapper)
        {
            _newRepository = newRepository;
            _mapper = mapper;
        }
        public NewModel AddNew(NewModel newModel)
        {
            var newToAdd = _mapper.Map<New>(newModel);
            var neww = _newRepository.AddNew(newToAdd);
            if (neww != null)
            {
                return newModel;
            }
            return null;
        }

        public NewModel DeleteNew(int id)
        {
            var newDel = _newRepository.DeleteNew(id);
            if (newDel != null)
            {
                var newResult = _mapper.Map<NewModel>(newDel);
                return newResult;
            }
            return null;
        }

        public NewModel GetNew(int id)
        {
            var newGet = _newRepository.GetNew(id);
            if (newGet != null)
            {
                var newResult = _mapper.Map<NewModel>(newGet);
                return newResult;
            }
            return null;
        }

        public List<NewModel> GetNews()
        {
            var news = _newRepository.GetNews();
            if (news != null)
            {
                var newsResult = _mapper.Map<List<NewModel>>(news);
                return newsResult;
            }
            return null;
        }

        public NewModel UpdateNew(int id, NewModel newModel)
        {
            var newToUpdate = _mapper.Map<New>(newModel);
            var newUpdate = _newRepository.UpdateNew(id, newToUpdate);
            if (newUpdate != null)
            {
                var newResult = _mapper.Map<NewModel>(newUpdate);
                return newResult;
            }
            return null;
        }
    }
}
