using Microsoft.AspNetCore.Mvc;
using AppWebHeiter.Data;
using AppWebHeiter.Models;

namespace AppWebHeiter.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDBContext _db;
        private readonly IWebHostEnvironment _host;

        public ProductsController(AppDBContext db, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            this._host = hostEnvironment;
        }

        public IActionResult Index()
        {
            var id_usuario = HttpContext.Session.GetInt32("Id");
            if (id_usuario == null)
                return RedirectToAction("Index", "Login");

            var objProdList = _db.tb_produtos.OrderByDescending(v=>v.Preco).ToList();
            return View(objProdList);
        }

        public IActionResult Detalhes(int? id)
        {
            var id_usuario = HttpContext.Session.GetInt32("Id");
            if (id_usuario == null)
                return RedirectToAction("Index", "Login");

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var produtoFromDb = _db.tb_produtos.FirstOrDefault(v=>v.Id == id);

            if (produtoFromDb == null)
            {
                return NotFound();
            }
            return PartialView(produtoFromDb);
        }

            //GET
        public IActionResult Create()
        {
            var id_usuario = HttpContext.Session.GetInt32("Id");
            if (id_usuario == null)
                return RedirectToAction("Index", "Login");

            return View();
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Create(Products produto)
        {
            if(produto.Img !=null)
            { 
                string wwwRootPath = _host.WebRootPath;
                string nomeFileImg = Path.GetFileNameWithoutExtension(produto.Img.FileName);
                string extensao = Path.GetExtension(produto.Img.FileName);
                produto.NomeArquivo = nomeFileImg = nomeFileImg + extensao;
                string path = Path.Combine(wwwRootPath + "/Images/", nomeFileImg);
                using (var fileStream = new FileStream(path, FileMode.Create)) 
                {
                    await produto.Img.CopyToAsync(fileStream);
                }
            }
            _db.tb_produtos.Add(produto);
                _db.SaveChanges();
                return RedirectToAction("Index");
        }
    }
}
