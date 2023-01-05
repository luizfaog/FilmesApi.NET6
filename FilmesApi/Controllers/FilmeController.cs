using FilmesApi.Data;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;

        public FilmeController(FilmeContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void AdicionaFilme([FromBody] Filme filme) // "FromBody" define que os parametros viram do body
        {
            
            _context.Filmes.Add(filme); // add a info no banco
            _context.SaveChanges(); // salva a info no banco
            Console.WriteLine(filme.Titulo);
            Console.WriteLine(filme.Duracao);
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperaFilmes() //Em vez de usar o tipo List<>, o IEnumerable<> é mais abstrato
        {
            return _context.Filmes;
        }

        [HttpGet("{id}")] // Define outro parametro de busca na Url
        public IActionResult RecuperaFilmePorId(int id) // tipo IActionResult para usar os retornos https (Ok, NotFound, BadRequest...)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.id == id);
            if (filme == null)
                return NotFound();
            return Ok(filme);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilmes(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.id == id); // busca no banco o filme com id igual ao passado por parametro
            if (filme == null) 
                return NotFound(); // se nao encontrar retorna NotFound
            _context.Remove(filme); // se encontrar remove o filme,
            _context.SaveChanges(); // salva as alterações,
            return NoContent(); // e retorna NoContent 
        }
    }
}
