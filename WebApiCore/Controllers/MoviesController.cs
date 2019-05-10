using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IEnumerable<MovieDTO> GetAll()
        {
            return _movieService.GetAll();
        }
        [HttpGet("{id}")]
        public MovieDTO GetById(int id)
        {
            return _movieService.GetById(id);
        }
        [HttpPost]
        public ActionResult Post(MovieDTO dto)
        {
            var result = _movieService.Create(dto);
            if (result)
                return Ok();
            return BadRequest();
        }
        [HttpPut]
        public ActionResult Put(MovieDTO dto)
        {
            var result = _movieService.Update(dto);
            if (result)
                return Ok();
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _movieService.Delete(id);
            if (result)
                return Ok();
            return BadRequest();
        }
    }
}