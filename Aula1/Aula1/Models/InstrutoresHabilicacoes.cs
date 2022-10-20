namespace Aula1.Models
{
    public class InstrutoresHabilicacoes
    {
        public int idHabilicacao { get; set; }
        public int idInstrutor { get; set; }
        public DateTime Data_obtencao { get; set; }
        public DateTime Data_validade { get; set; }
        public bool ativo { get; set; }
    }
}
