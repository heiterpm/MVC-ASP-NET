using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AppWebHeiter.Data;

namespace AppWebHeiter.Models
{
    public class Products
    {
        private readonly AppDBContext _db;

        public Products(AppDBContext db)
        {
            _db = db;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Descricao { get; set; }
        [Required]
        public float Preco { get; set;}
        [Required]
        public int QtdEstoque { get; set; }

        public string NomeArquivo { get; set; }
        [NotMapped]
        public IFormFile Img { get; set; }

        //public Object BuscaProdutos()
        //{
        //    var objProdList = _db.tb_produtos.ToList().OrderBy(v => v.Preco);
        //    return objProdList;
        //}
    }
}
