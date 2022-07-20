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

        public IActionResult Index(Login model, Products prod )
        {
            if (model.GetSession(HttpContext) == null)
                return RedirectToAction("Index", "Login");
            return View(prod.GetProducts(_db));
        }

        public IActionResult Detalhes(int? id, Login model, Products prod)
        {
            if (model.GetSession(HttpContext) == null)
                return RedirectToAction("Index", "Login");

            if (id == null || id == 0)
            {
                return NotFound();
            }

            if (prod.GetProduct(id, _db) == null)
            {
                return NotFound();
            }
            return PartialView(prod.GetProduct(id,_db));
        }

            //GET
        public IActionResult Create(Login model)
        {
            if (model.GetSession(HttpContext) == null)
                return RedirectToAction("Index", "Login");

            return View();
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Create(Products prod)
        {
            prod.CreateProduct(_db, _host, prod);
                return RedirectToAction("Index");
        }
    }
}
