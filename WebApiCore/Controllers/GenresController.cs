using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;
        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreDTO>>> GetAll()
        {
            var dto = await _genreService.GetAll();
            if (dto == null)
                return NotFound();
            return Ok(dto);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GenreDTO>> GetById(int id)
        {
            var dto = await _genreService.GetById(id);
            if (dto == null)
                return NotFound();
            return Ok(dto);
        }
        [HttpPost]
        public async Task<ActionResult> Post(GenreDTO dto)
        {
            var result = await _genreService.Create(dto);
            if (result)
                return Ok();
            return BadRequest();
        }
        [HttpPut]
        public async Task<ActionResult> Put(GenreDTO dto)
        {
            var result = await _genreService.Update(dto);
            if (result)
                return Ok();
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _genreService.Delete(id);
            if (result)
                return Ok();
            return BadRequest();
        }
    }
}