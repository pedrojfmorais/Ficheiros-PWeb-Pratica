using Aula1.Data;

namespace Aula1.Models
{
    public class CategoriaCarta
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Disponivel { get; set; }
        public Curso[] listaCursos { get; set; }
    }
}
