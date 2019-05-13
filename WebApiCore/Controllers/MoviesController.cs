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
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetAll()
        {
            var dto = await _movieService.GetAll();
            if (dto == null)
                return NotFound();
            return Ok(dto);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDTO>> GetById(int id)
        {
            var dto = await _movieService.GetById(id);
            if (dto == null)
                return NotFound();
            return Ok(dto);
        }
        [HttpPost]
        public async Task<ActionResult> Post(MovieDTO dto)
        {
            var result = await _movieService.Create(dto);
            if (result)
                return Ok();
            return BadRequest();
        }
        [HttpPut]
        public async Task<ActionResult> Put(MovieDTO dto)
        {
            var result = await _movieService.Update(dto);
            if (result)
                return Ok();
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _movieService.Delete(id);
            if (result)
                return Ok();
            return BadRequest();
        }
    }
}