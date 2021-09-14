using SeriesApi.Data;
using SeriesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SeriesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SerieController : ControllerBase
    {
        private SerieContext _context;

        public SerieController(SerieContext context) 
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionarSerie([FromBody] Serie serie) 
        {
            _context.Series.Add(serie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaSeriesPorId), new { Id = serie.Id }, serie);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSeriesPorId(int id) 
        {
            Serie serie = _context.Series.FirstOrDefault(serie => serie.Id == id);
            if (serie != null) 
            {
                return Ok(serie);
            }

            return NotFound();
        }

        [HttpPut("{id}")]

        public IActionResult AtualizaSerie(int id, [FromBody] Serie serieNovo)
        {
            Serie serie = _context.Series.FirstOrDefault(serie => serie.Id == id);
            if (serie == null)
            {
                return NotFound();
            }

            serie.Titulo = serieNovo.Titulo;
            serie.Genero = serieNovo.Genero;
            serie.Temporada = serieNovo.Temporada;
            serie.Episodio = serieNovo.Episodio;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaSerie(int id)
        {
            Serie serie = _context.Series.FirstOrDefault(serie => serie.Id == id);
            if (serie == null)
            {
                return NotFound();
            }
            _context.Remove(serie);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
