using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AppWebHeiter.Data;

namespace AppWebHeiter.Models
{
    public class Products
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string? Descricao { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public float Preco { get; set; }
        [Required]
        public int QtdEstoque { get; set; }

        public string? NomeArquivo { get; set; }
        [NotMapped]
        public IFormFile Img { get; set; }

        public List<Products> GetProducts(AppDBContext db)
        {
            return db.tb_produtos.OrderByDescending(v => v.Preco).ToList();
        }
        public Products? GetProduct(int? id ,AppDBContext db)
        {
            return db.tb_produtos.FirstOrDefault(v => v.Id == id);
        }
        public void CreateProduct(AppDBContext db, IWebHostEnvironment hostEnvironment, Products produto)
        {
            var _host = hostEnvironment;
            if (this.Img != null)
            {
                string wwwRootPath = _host.WebRootPath;
                string nomeFileImg = Path.GetFileNameWithoutExtension(this.Img.FileName);
                string extensao = Path.GetExtension(this.Img.FileName);
                this.NomeArquivo = nomeFileImg = nomeFileImg + extensao;
                string path = Path.Combine(wwwRootPath + "/Images/", nomeFileImg);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    this.Img.CopyToAsync(fileStream);
                }
            }
            db.tb_produtos.Add(produto);
            db.SaveChanges();
        }
    }
}
