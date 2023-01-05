using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Models
{
    public class Filme
    {
        [Key] // identifica qual a chave primária no banco
        [Required] // diz que é obrigatório
        public int id { get; set; }
        [Required(ErrorMessage = "O Título é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O Genero é obrigatório")]
        [MaxLength(50, ErrorMessage = "O tamanho do gênero não pode exceder 50 caracteres")] // tamanho maximo de caracteres
        public string Genero { get; set; }
        [Required(ErrorMessage = "A Duração é obrigatória")]
        [Range(70, 600, ErrorMessage = "A duração deve ter entre 70 e 600 minutos")] // define um range
        public int Duracao { get; set; }
    }
}
