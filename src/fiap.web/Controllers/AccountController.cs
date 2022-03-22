using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace fiapweb2022.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Times");
            }

            return View();
        }

        [HttpPost]
        public  async Task<IActionResult> Index(ViewModels.LoginViewModel model)
        {
            //simulando acesso ao DB
            if (model.UserName == "jorge" && model.Password =="123123")
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, model.UserName));
                

                var id = new ClaimsIdentity(claims,"password");
                var principal = new ClaimsPrincipal(id);

                await HttpContext.SignInAsync("app", principal, new AuthenticationProperties { IsPersistent = model.IsPersistent });
              //  await HttpContext.SignOutAsync();
                
                return RedirectToAction("Index", "Times");

            }

            return View(model);
        }
    }
}
