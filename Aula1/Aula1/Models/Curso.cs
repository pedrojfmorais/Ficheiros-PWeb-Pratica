using System.ComponentModel.DataAnnotations;
namespace Aula1.Models
{
    public class Curso
    {
        public int Id { get; set; }
        [Display(Name = "Nome", Prompt = "Introduza o nome do curso",
            Description = "Nome do novo curso a inserir")]
        public string Nome { get; set; }
        [Display(Name = "Disponibilidade", Prompt = "O curso está disponivel?",
            Description = "Se o curso se encontra disponivel")]
        public bool Disponivel { get; set; }
        [Display(Name = "Descrição", Prompt = "Introduza uma descrição para o curso",
            Description = "Descrição do curso")]
        public string Descricao { get; set; }
        [Display(Name = "Descrição Resumida", Prompt = "Introduza um resumo da descrição",
            Description = "Descrição Resumida do curso")]
        public string DescricaoResumida { get; set; }
        [Display(Name = "Requisitos", Prompt = "Introduza os requisitos do curso",
            Description = "Requisitos do curso")]
        public string Requisitos { get; set; }
        [Display(Name = "Idade mínima", Prompt = "Introduza a idade Mínima", 
            Description = "Idade mínima para poder frequentar esta formação")]
        [Range(14, 100, ErrorMessage = "Mínimo: 14 anos, máximo: 100 anos")]
        public int IdadeMinima { get; set; }
        [Display(Name = "Preço", Prompt = "Introduza o preço do curso",
            Description = "O preço a pagar para tirar o curso")]
        [Range(1, 10000, ErrorMessage = "Mínimo: 1 euro, máximo: 10000 euros")]
        public decimal Preco { get; set; }
        [Display(Name = "Em Destaque", Prompt = "O curso está em destaque?",
            Description = "Se o curso se encontra em destaque")]
        public bool EmDestaque { get; set; }
        [Display(Name = "Categoria", Prompt = "Insira a categoria do curso",
            Description = "Categoria a que o curso pertence")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
