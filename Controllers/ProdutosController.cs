using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_Loja_Sapatos.Data;
using Projeto_Loja_Sapatos.Models;

namespace Projeto_Loja_Sapatos.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Produtos
        public async Task<IActionResult> Produto()
        {

            var modelos = await _context.Modelos.ToListAsync();

            List<ModeloViewModel> modelosViewModel = new List<ModeloViewModel>();
            foreach(var e in modelos)
            {
                var quantidade = await _context.Estoques.FirstOrDefaultAsync(q => q.Id == e.Id_fornecedor);

                ModeloViewModel modeloVM = new ModeloViewModel();

                modeloVM.CodigoRef = e.CodigoRef;
                modeloVM.Nome = e.Nome;
                modeloVM.Cor = e.Cor;
                modeloVM.Id = e.Id;
                modeloVM.Id_fornecedor = e.Id_fornecedor;
                modeloVM.Tamanho = e.Tamanho;
                modeloVM.Qtd = Convert.ToInt32(quantidade);
            }
            return View(modelosViewModel);
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelos = await _context.Modelos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelos == null)
            {
                return NotFound();
            }

            return View(modelos);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Id_fornecedor,Nome,CodigoRef,Cor,Tamanho,Qtd")] ModeloViewModel modelos)
        {
            if (ModelState.IsValid)
            {
                var estoque = new Estoque();

                estoque.Id_Modelo = modelos.Id;
                estoque.Qtd = modelos.Qtd;

                _context.Add(modelos);
                _context.Add(estoque);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Produto));
            }
            return View(modelos);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelos = await _context.Modelos.FindAsync(id);
            if (modelos == null)
            {
                return NotFound();
            }
            return View(modelos);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Id_fornecedor,Nome,CodigoRef,Cor,Tamanho,Qtd")] ModeloViewModel modelos)
        {
            if (id != modelos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelosExists(modelos.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Produto));
            }
            return View(modelos);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelos = await _context.Modelos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelos == null)
            {
                return NotFound();
            }

            return View(modelos);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modelos = await _context.Modelos.FindAsync(id);
            _context.Modelos.Remove(modelos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Produto));
        }

        private bool ModelosExists(int id)
        {
            return _context.Modelos.Any(e => e.Id == id);
        }
    }
}
