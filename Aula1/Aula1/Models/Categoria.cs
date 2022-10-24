using System.ComponentModel.DataAnnotations;
namespace Aula1.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        [Display(Name = "Nome", Prompt = "Introduza o nome da categoria",
            Description = "Nome da nova categoria a inserir")]
        public string Nome { get; set; }
        [Display(Name = "Descrição", Prompt = "Introduza uma descrição para a categoria",
            Description = "Descrição da categoria")]
        public string Descricao { get; set; }
        [Display(Name = "Disponibilidade", Prompt = "A categoria está disponivel?",
            Description = "Se a categoria se encontra disponivel")]
        public bool Disponivel { get; set; }
        public ICollection<Curso> Cursos { get; set; }
    }
}
