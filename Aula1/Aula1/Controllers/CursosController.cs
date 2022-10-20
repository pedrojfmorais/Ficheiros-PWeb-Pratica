using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aula1.Data;
using Aula1.Models;

namespace Aula1.Controllers
{
    public class CursosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CursosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cursos
        public async Task<IActionResult> Index(bool? disponivel)
        {
            if(disponivel != null)
            {
                if (disponivel == true)
                    ViewData["Title"] = "Lista de cursos Activos";
                else
                    ViewData["Title"] = "Lista de cursos Inativos";
                return View(await _context.Cursos.Where(c => c.Disponivel == disponivel).ToListAsync());
            }

            ViewData["Title"] = "Lista de cursos";
            return View(await _context.Cursos.ToListAsync());
        }
        /*
        [HttpPost]
        public async Task<IActionResult> Index(string textoAPesquisar )
        {
            return View(await _context.Cursos.Where(
                c=>c.Nome.Contains(textoAPesquisar) 
                || c.Descricao.Contains(textoAPesquisar)
                ).ToListAsync());
        }
        */
        // GET: Cursos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cursos == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        [HttpPost]
        public async Task<IActionResult> Search([Bind("TextoAPesquisar")]
            PesquisaCursoViewModel pesquisaCurso)
        {

            pesquisaCurso.ListaDeCursos = await _context.Cursos.Where(
                c => c.Nome.Contains(pesquisaCurso.TextoAPesquisar)
                || c.Descricao.Contains(pesquisaCurso.TextoAPesquisar)
                || c.Categoria.Nome.Contains(pesquisaCurso.TextoAPesquisar)
                ).ToListAsync();

            pesquisaCurso.NumResultados = pesquisaCurso.ListaDeCursos.Count;

            return View(pesquisaCurso);
        }

        // GET: Cursos/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categoria.ToList(), "Id", "Nome");
            return View();
        }

        // POST: Cursos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Disponivel,CategoriaId,Descricao,DescricaoResumida,Requisitos,IdadeMinima,Preco,EmDestaque")] Curso curso)
        {
            //temporário
            ViewData["CategoriaId"] = new SelectList(_context.Categoria.ToList(), "Id", "Nome");

            ModelState.Remove(nameof(curso.Categoria));
            if (ModelState.IsValid)
            {
                _context.Add(curso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(curso);
        }

        // GET: Cursos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categoria.ToList(), "Id", "Nome");

            if (id == null || _context.Cursos == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }

        // POST: Cursos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Disponivel,CategoriaId,Descricao,DescricaoResumida,Requisitos,IdadeMinima,Preco,EmDestaque")] Curso curso)
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categoria.ToList(), "Id", "Nome");

            if (id != curso.Id)
            {
                return NotFound();
            }

            //temporário
            ModelState.Remove(nameof(curso.Categoria));
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoExists(curso.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(curso);
        }

        // GET: Cursos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cursos == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cursos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cursos'  is null.");
            }
            var curso = await _context.Cursos.FindAsync(id);
            if (curso != null)
            {
                _context.Cursos.Remove(curso);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoExists(int id)
        {
          return _context.Cursos.Any(e => e.Id == id);
        }
    }
}
