using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Aula1.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "O meu Avatar")]
        public byte[]? Avatar { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        [PersonalData]
        public DateTime DataNascimento { get; set; }
        [PersonalData]
        public int NIF { get; set; }

        public ICollection<Agendamento> Agendamentos { get; set; }
    }
}
