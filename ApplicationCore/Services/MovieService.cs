using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationCore.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Movie> _movieRepository;
        public MovieService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _movieRepository = _unitOfWork.GenericRepository<Movie>();
        }

        public bool Create(MovieDTO t)
        {
            var entity = new Movie
            {
                GenreID = t.GenreID,
                Price = t.Price,
                ReleaseDate = t.ReleaseDate,
                Title = t.Title
            };
            try
            {
                _movieRepository.Create(entity);
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
                _movieRepository.Delete(id);
                _unitOfWork.SaveAsync();
            }
            catch (Exception e)
            {
                _unitOfWork.WriteLog(e.ToString());
                return false;
            }
            return true;
        }

        public IEnumerable<MovieDTO> GetAll()
        {
            var entities = _movieRepository.GetAll();
            if (entities == null)
                return null;
            var dto = from entity in entities
                      select (new MovieDTO
                      {
                          GenreID = entity.GenreID,
                          ID = entity.ID,
                          Price = entity.Price,
                          ReleaseDate = entity.ReleaseDate,
                          Title = entity.Title
                      });
            return dto;
        }

        public MovieDTO GetById(int id)
        {
            var entity = _movieRepository.GetById(id);
            if (entity == null)
                return null;
            var dto = new MovieDTO
            {
                GenreID = entity.GenreID,
                ID = entity.ID,
                Price = entity.Price,
                ReleaseDate = entity.ReleaseDate,
                Title = entity.Title
            };
            return dto;
        }

        public bool Update(MovieDTO t)
        {
            var entity = new Movie
            {
                ID = t.ID,
                GenreID = t.GenreID,
                Price = t.Price,
                ReleaseDate = t.ReleaseDate,
                Title = t.Title
            };
            try
            {
                _movieRepository.Update(entity);
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
