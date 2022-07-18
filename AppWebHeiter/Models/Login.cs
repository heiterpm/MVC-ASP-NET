using System.ComponentModel.DataAnnotations;

namespace AppWebHeiter.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
