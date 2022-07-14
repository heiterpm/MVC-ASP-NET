using Microsoft.AspNetCore.Mvc;
using app_mvc.Models;

namespace app_mvc.Controllers
{
    public class AlunoController : Controller
    {
        // GET: Alunos
        public IActionResult Index()
        {
            Aluno aluno = new Aluno();
            aluno.CriarAluno();

            return View(aluno.BuscarAluno());
        }
    }
}