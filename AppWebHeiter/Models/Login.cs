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
        public string Usuario { get; set; }

        [Required]
        public string Senha { get; set; }

        public void SetSession(int Id, HttpContext httpContext) => httpContext.Session.SetInt32("Id", Id);

        public void RemoveSession(HttpContext httpContext) => httpContext.Session.Remove("Id");

        public int? GetSession(HttpContext httpContext) => httpContext.Session.GetInt32("Id");
    }
}
