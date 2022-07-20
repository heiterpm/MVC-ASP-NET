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
            ViewBag.mensagem = "";
            return View();
        }

        [HttpPost]
        public IActionResult Index(Login model)
        {
            var usuario = _db.tb_usuarios.Where(conta => conta.Usuario == model.Usuario).FirstOrDefault();
            if (usuario?.Nome == null)
            {
                ViewBag.mensagem = "Usuario não encontrado";
                return View();
            }
            if (usuario?.Senha != model.Senha)
            {
                ViewBag.mensagem = "Senha Incorreta";
                return View();
            } else
                HttpContext.Session.SetInt32("Id",model.Id);
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("Id");

            return RedirectToAction("Index", "Home");
        }
    }
}
