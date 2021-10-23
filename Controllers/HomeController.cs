﻿using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        public IActionResult CadastroFornecedor()
        {
            return View();
        }

        public IActionResult ListarFornecedor()
        {
            return View();
        }

        public IActionResult ListarModelos()
        {
            return View();
        }

        public IActionResult ListarVendas()
        {
            return View();
        }

        public IActionResult Produtos()
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
