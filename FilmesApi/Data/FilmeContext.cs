using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opts) // opcoes de acesso ao banco
            : base(opts)
        {

        }
        public DbSet<Filme> Filmes { get; set; }  // DbSet = conjunto de dados
    }
}
