﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tcc_Senai.Data;
using Tcc_Senai.Models;

namespace Tcc_Senai.Controllers
{
    public class TurmaController : Controller
    {
        private readonly IESContext _context;
        public TurmaController(IESContext context)
        {
            this._context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Turmas.Include(i => i.Curso).OrderBy(c => c.NomeTurma).ToListAsync());
          

        }
        // GET: Turma Create
        public ActionResult Create()
        {
            var cursos = _context.Cursos.OrderBy(i => i.NomeCurso).ToList();
            cursos.Insert(0, new Curso() { IdCurso = 0, NomeCurso = "Selecione o Curso" });
            ViewBag.Cursos = cursos;
                return View();
        }
        //POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Periodo", "NomeTurma", "NomeCurso, IdCurso")] Turma turma)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(turma);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(turma);
        }
        // GET: Turma/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var turma = await _context.Turmas.SingleOrDefaultAsync(m => m.IdTurma == id);
            if (turma == null)
            {
                return NotFound();
            }
            ViewBag.Cursos = new SelectList(_context.Cursos.OrderBy(b => b.NomeCurso), "IdCurso", "NomeCurso", turma.IdCurso);
            return View(turma);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IdTurma, Periodo, NomeTurma, IdCurso")] Turma turma)
        {
            if (id != turma.IdTurma)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurmaExists(turma.IdTurma))
                    {
                        NotFound();


                        return NotFound();
                    }
                   
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Cursos = new SelectList(_context.Cursos.OrderBy(b => b.NomeCurso), "IdCurso", "NomeCurso", turma.IdCurso);
            return View(turma);
        }
        private bool TurmaExists(long? id)
        {
            return _context.Turmas.Any(e => e.IdTurma == id);
        }

        // GET: Turma/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var turma = await _context.Turmas.SingleOrDefaultAsync(m => m.IdTurma == id);
            _context.Cursos.Where(i => turma.IdCurso ==
            i.IdCurso).Load();
            if (turma == null)
            {
                return NotFound();
            }
            return View(turma);
        }
        // POST: Turma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var turma = await _context.Turmas.SingleOrDefaultAsync(m => m.IdTurma == id);
            _context.Turmas.Remove(turma);
            TempData["Message"] = "Turma " + turma.NomeTurma.ToUpper() + "foi removido";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}