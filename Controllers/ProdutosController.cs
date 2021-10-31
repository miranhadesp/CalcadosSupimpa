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
            return View(await _context.Modelos.ToListAsync());
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
        public async Task<IActionResult> Create([Bind("Id,Id_fornecedor,Nome,CodigoRef,Cor,Tamanho")] Modelos modelos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modelos);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Id_fornecedor,Nome,CodigoRef,Cor,Tamanho")] Modelos modelos)
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
