using Microsoft.AspNetCore.Identity;

namespace Aula1.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        [PersonalData]
        public DateTime DataNascimento { get; set; }
        [PersonalData]
        public int NIF { get; set; }

    }
}
