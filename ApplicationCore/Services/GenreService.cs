using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<bool> Create(GenreDTO t)
        {
            var entity = new Genre
            {
                Name = t.Name
            };
            try
            {
                _genreRepository.Create(entity);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception e)
            {
                _unitOfWork.WriteLog(e.ToString());
                return false;
            }
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            if (id < 1)
                return false;
            try
            {
                _genreRepository.Delete(id);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception e)
            {
                _unitOfWork.WriteLog(e.ToString());
                return false;
            }
            return true;
        }

        public async Task<IEnumerable<GenreDTO>> GetAll()
        {
            var entities = await _genreRepository.GetAllAsync();
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

        public async Task<GenreDTO> GetById(int id)
        {
            var entity = await _genreRepository.GetByIdAsync(id);
            if (entity == null)
                return null;
            var dto = new GenreDTO
            {
                ID = entity.ID,
                Name = entity.Name
            };
            return dto;
        }

        public async Task<bool> Update(GenreDTO t)
        {
            var entity = new Genre
            {
                ID = t.ID,
                Name = t.Name
            };
            try
            {
                _genreRepository.Update(entity);
                await _unitOfWork.SaveAsync();
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
