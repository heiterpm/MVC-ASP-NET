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

        public IActionResult Index( )
        {
            var listProd = _db.tb_produtos.OrderByDescending(v => v.Preco).ToList();
            if (HttpContext.Session.GetInt32("Id") == null)
                return RedirectToAction("Index", "Login");
            return View(listProd);
        }

        public IActionResult Detalhes(int? id)
        {
            if (HttpContext.Session.GetInt32("Id") == null)
                return RedirectToAction("Index", "Login");

            var prod = _db.tb_produtos.FirstOrDefault(v => v.Id == id);


            if (id == null || id == 0)
            {
                return NotFound();
            }

            if (prod == null)
            {
                return NotFound();
            }
            return PartialView(prod);
        }

            //GET
        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("Id") == null)
                return RedirectToAction("Index", "Login");

            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Create(Products prod)
        {
            if (prod.Img != null)
            {
                string wwwRootPath = _host.WebRootPath;
                string nomeFileImg = Path.GetFileNameWithoutExtension(prod.Img.FileName);
                string extensao = Path.GetExtension(prod.Img.FileName);
                prod.NomeArquivo = nomeFileImg = nomeFileImg + extensao;
                string path = Path.Combine(wwwRootPath + "/Images/", nomeFileImg);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    prod.Img.CopyToAsync(fileStream);
                }
            }
            _db.tb_produtos.Add(prod);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
