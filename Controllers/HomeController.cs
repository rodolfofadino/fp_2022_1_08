using Microsoft.AspNetCore.Mvc;

namespace fiap_web_2022.Controllers
{
    public class HomeController :Controller
    {

        [HttpGet]
        public IActionResult Index([FromQuery]string? appName)
        {
           

            ViewData["Nome"] = "Filipe";
            ViewBag.SobreNome = "Augusto";

            var model = new Aluno() { Nome = "Jorge", Sobrenome = "Amado" };
            ViewBag.Aluno = model;

            //return View("home");
            return View(model);
        }

        [HttpGet]
        public IActionResult Pesado()
        {
            var lista = new List<Aluno>();
            for (int i = 0; i < 3000000; i++)
            {
                lista.Add(new Aluno() { Nome = "Jorge", Sobrenome = "Amado" });
            }
            ViewBag.Alunos = lista.ToList();

            //ViewData["Nome"] = "Filipe";
            //ViewBag.SobreNome = "Augusto";

            //var model = new Aluno() { Nome = "Jorge", Sobrenome = "Amado" };
            //ViewBag.Aluno = model;

            //return View("home");
            return View("home");
        }

        //[HttpPost]
        //public IActionResult Index([FromBody]Aluno aluno)
        //{
            
        //    //return View("home");
        //    return View(aluno);
        //}




        //public string Index()
        //{
        //    return "boa noite";
        //}
    }
}
