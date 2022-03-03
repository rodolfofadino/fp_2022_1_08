using fiapweb2022.Models;
using Microsoft.AspNetCore.Mvc;

namespace fiapweb2022.Controllers
{
    public class TimesController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Time model)
        {
            //todo:salvar
            return View();
        }
    }
}
