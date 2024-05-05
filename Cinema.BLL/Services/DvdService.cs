using AutoMapper;
using Cinema.BLL.Interfaces;
using Cinema.BLL.Models;
using Cinema.DAL.Entities;
using Cinema.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.BLL.Services
{
    public class DvdService : IDvdService
    {
        private readonly IMapper _mapper;
        private readonly IDvdRepository _dvdRepository;
        public DvdService(IMapper mapper, IDvdRepository dvdRepository)
        {
            _mapper = mapper;
            _dvdRepository = dvdRepository;
        }

        public void Delete(int id)
        {
            _dvdRepository.Delete(id);
            _dvdRepository.Save();
        }

        public IEnumerable<DvdModel> GetAll()
        {
            return _mapper.Map<IEnumerable<DvdModel>>(_dvdRepository.GetAll());
        }

        public DvdModel? GetById(int id)
        {
            return _mapper.Map<DvdModel>(_dvdRepository.GetById(id));
        }

        public void Insert(DvdModel model)
        {
            _dvdRepository.Insert(_mapper.Map<Dvd>(model));
            _dvdRepository.Save();
        }

        public void Update(DvdModel model)
        {
            _dvdRepository.Update(_mapper.Map<Dvd>(model));
            _dvdRepository.Save();
        }
    }
}
