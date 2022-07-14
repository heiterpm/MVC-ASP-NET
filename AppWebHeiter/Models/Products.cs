using System.ComponentModel.DataAnnotations;

namespace AppWebHeiter.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Descricao { get; set; }
        [Required]
        public float Preco { get; set;}
        [Required]
        public int QtdEstoque { get; set;}    
    }
}
