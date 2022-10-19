using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Aula1.Models
{
    public class PesquisaCursoViewModel
    {
        public List<Curso> ListaDeCursos { get; set; }
        public int NumResultados { get; set; }
        [Display(Name = "Pesquisa de cursos", Prompt = "introduza o texto a pesquisar")]
        public string TextoAPesquisar { get; set; }
    }
}
