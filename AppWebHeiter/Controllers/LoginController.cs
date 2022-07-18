using Microsoft.AspNetCore.Mvc;
using AppWebHeiter.Data;
using AppWebHeiter.Models;

namespace AppWebHeiter.Controllers
{
    public class LoginController : Controller
    {

        private readonly AppDBContext _db;
        public LoginController(AppDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Index(Login model)
        //{
        //    var usuario = _db.tb_usuarios.Where(conta => conta.Usuario == model.Usuario && conta.Senha == model.Senha).FirstOrDefault();
        //    if(usuario?.Nome != null)
        //    {
        //        return RedirectToAction("Index","Home");
        //    }
        //    return View();
        //}
    [HttpPost]
    public JsonResult Logar(string nome, string senha) 
        {
            var usuario = _db.tb_usuarios.Where(conta => conta.Usuario == nome && conta.Senha == senha).FirstOrDefault();
            if (usuario?.Nome != null)
                {
                    Console.WriteLine("Entrei?");
                }
                    return Json(usuario);
        }
    }
}
