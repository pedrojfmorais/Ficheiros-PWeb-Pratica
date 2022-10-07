using Aula1.Models;
using Microsoft.AspNetCore.Routing.Constraints;

namespace Aula1.Data
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Disponivel { get; set; }
        public string Categoria { get; set; }
        public string Descricao { get; set; }
        public string DescricaoResumida { get; set; }
        public string Requisitos { get; set; }
        public int IdadeMinima { get; set; }
        public decimal Preco { get; set; }
        public bool EmDestaque { get; set; }
        public CategoriaCarta categoriaCarta { get; set; }

    }
}
