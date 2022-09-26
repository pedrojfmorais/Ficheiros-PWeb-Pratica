namespace Aula1.Data
{
    public class Agendamentos
    {
        public int idAgendamento { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public int idAluno { get; set; }
        public int idInstrutor { get; set; }
        public bool realizado { get; set; }
        public string observacoes { get; set; }

    }
}
