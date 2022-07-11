using CalculadoraMVC2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CalculadoraMVC2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Calculadora cal)
        {
            int a, b;
            a = cal.Num1;
            b = cal.Num2;
            if (cal.Operador == "   subtrair   ")
            {
                cal.Resultado = a - b;
            }
            else if (cal.Operador == " multiplicar ")
            {
                cal.Resultado = a * b;
            }
            else if (cal.Operador == "     dividir     ")
            {
                cal.Resultado = a / b;
            }
            else
            {
                cal.Resultado = a + b;
            }
            ViewData["result"] = cal.Resultado;

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