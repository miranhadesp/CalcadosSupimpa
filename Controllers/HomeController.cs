using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projeto_Loja_Sapatos.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Loja_Sapatos.Controllers
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

        public IActionResult Cliente()
        {
            return View("Views/Cliente/CadastrarCliente.cshtml");
        }

        public IActionResult CadastrarFornecedor()
        {
            return View("Views/Fornecedor/CadastroFornecedor.cshtml");
        }

        public IActionResult ListarFornecedor()
        {
            return View("Views/Fornecedor/ListarFornecedor.cshtml");
        }

        public IActionResult Modelos()
        {
            return View("Views/Modelos/ListarModelos.cshtml");
        }

        public IActionResult Vendas()
        {
            return View("Views/Vendas/ListarVendas.cshtml");
        }

        public IActionResult Produtos()
        {
            return View("Views/Produtos/Produto.cshtml");
        }

        public IActionResult Login()
        {
            return View("Views/Login/Logar.cshtml");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
