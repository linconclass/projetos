using Microsoft.AspNetCore.Mvc;
using Sistema_Vendas.Models;
using System.Diagnostics;

namespace Sistema_Vendas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Menu()
        {
            return View();
        }       

        [HttpGet]
        public IActionResult Login(int? id)
        {
            //para realizar logout
            if(id == null) 
            {
                if (id == 0)
                {
                    HttpContext.Session.SetString("IdUsuarioLogin", string.Empty);
                    HttpContext.Session.SetString("NomeUsuarioLogin", string.Empty);
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel Login)
        {
            if (ModelState.IsValid)
            {
                bool loginOK = Login.ValidarLogin();
                if (loginOK)
                {
                    HttpContext.Session.SetString("IdUsuarioLogin", Login.Id);
                    HttpContext.Session.SetString("NomeUsuarioLogin", Login.Nome);
                    return RedirectToAction("Menu", "Home");
                }
                else 
                {
                    TempData["ErrorLogin"] = "E-mail ou Senha são inválidos!";
                }
            }
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contato()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}