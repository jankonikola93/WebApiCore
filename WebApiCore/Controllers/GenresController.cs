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
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;
        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        [HttpGet]
        public IEnumerable<GenreDTO> GetAll()
        {
            return _genreService.GetAll();
        }
        [HttpGet("{id}")]
        public GenreDTO GetById(int id)
        {
            return _genreService.GetById(id);
        }
        [HttpPost]
        public ActionResult Post(GenreDTO dto)
        {
            var result = _genreService.Create(dto);
            if (result)
                return Ok();
            return BadRequest();
        }
        [HttpPut]
        public ActionResult Put(GenreDTO dto)
        {
            var result = _genreService.Update(dto);
            if (result)
                return Ok();
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _genreService.Delete(id);
            if (result)
                return Ok();
            return BadRequest();
        }
    }
}