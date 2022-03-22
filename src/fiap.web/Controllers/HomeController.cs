using fiapweb2022.core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;

namespace fiapweb2022.Controllers
{
    public class HomeController :Controller
    {

        public HomeController()
        {
        }

        [HttpGet]
        public IActionResult Login(string returnUr)
        {

            return Redirect(returnUr);
        }

        [HttpGet]
        public IActionResult Index([FromQuery]string? appName)
        {

            ViewData["Tag"] = "<script>alert('oi')</script>";
            ViewData["Nome"] = "Filipe";
            ViewBag.SobreNome = "Augusto";

            var model = new Aluno() { Nome = "Jorge", Sobrenome = "Amado" };
            ViewBag.Aluno = model;


            var lista = new List<Aluno>();
            for (int i = 0; i < 10; i++)
            {
                lista.Add(new Aluno() { Nome = $"Jorge {i}", Sobrenome = "Amado" });
            }
            ViewBag.Alunos = lista.ToList();

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
