using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationCore.Services
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Genre> _genreRepository;
        public GenreService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _genreRepository = _unitOfWork.GenericRepository<Genre>();
        }

        public bool Create(GenreDTO t)
        {
            var entity = new Genre
            {
                Name = t.Name
            };
            try
            {
                _genreRepository.Create(entity);
                _unitOfWork.SaveAsync();
            }
            catch (Exception e)
            {
                _unitOfWork.WriteLog(e.ToString());
                return false;
            }
            return true;
        }

        public bool Delete(int id)
        {
            if (id < 1)
                return false;
            try
            {
                _genreRepository.Delete(id);
                _unitOfWork.SaveAsync();
            }
            catch (Exception e)
            {
                _unitOfWork.WriteLog(e.ToString());
                return false;
            }
            return true;
        }

        public IEnumerable<GenreDTO> GetAll()
        {
            var entities = _genreRepository.GetAll();
            if (entities == null)
                return null;
            var dto = from entity in entities
                      select (new GenreDTO
                      {
                          ID = entity.ID,
                          Name = entity.Name
                      });
            return dto;
        }

        public GenreDTO GetById(int id)
        {
            var entity = _genreRepository.GetById(id);
            if (entity == null)
                return null;
            var dto = new GenreDTO
            {
                ID = entity.ID,
                Name = entity.Name
            };
            return dto;
        }

        public bool Update(GenreDTO t)
        {
            var entity = new Genre
            {
                ID = t.ID,
                Name = t.Name
            };
            try
            {
                _genreRepository.Update(entity);
                _unitOfWork.SaveAsync();
            }
            catch (Exception e)
            {
                _unitOfWork.WriteLog(e.ToString());
                return false;
            }
            return true;
        }
    }
}
