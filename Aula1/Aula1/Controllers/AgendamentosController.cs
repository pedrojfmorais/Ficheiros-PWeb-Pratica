﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aula1.Data;
using Aula1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aula1.Models.ViewModels;

namespace Aula1.Controllers
{
    public class AgendamentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AgendamentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Pedido()
        {
            ViewData["TipoDeAulaId"] = new SelectList(_context.TipoDeAula, "Id", "Nome");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Calcular([Bind("Cliente,DataInicio,DataFim,TipoDeAulaId")] AgendamentoViewModel pedido)
        {
            ViewData["TipoDeAulaId"] = new SelectList(_context.TipoDeAula, "Id", "Nome");

            double NrHoras = 0;
            double NrMinutos = 0;

            if (pedido.DataInicio > pedido.DataFim)
                ModelState.AddModelError("DataInicio", "A data de inicio não pode ser maior que a data de fim");

            var tipoDeAula = _context.TipoDeAula.Find(pedido.TipoDeAulaId);
            if (tipoDeAula == null)
            {
                ModelState.AddModelError("TipoDeAulaId", "Tipo de aula inválido");
            }

            if (ModelState.IsValid)
            {
                NrHoras = (pedido.DataFim - pedido.DataInicio).TotalHours;
                NrMinutos = (pedido.DataFim - pedido.DataInicio).TotalMinutes;

                Agendamento x = new Agendamento();
                x.Cliente = pedido.Cliente;
                x.DataFim = pedido.DataFim;
                x.DataInicio = pedido.DataInicio;
                x.DuracaoMinutos = NrMinutos;
                x.DuracaoHoras = NrHoras;
                x.TipoDeAulaId = pedido.TipoDeAulaId;

                x.Preco = tipoDeAula.ValorHora * (decimal)NrHoras;
                x.tipoDeAula = tipoDeAula;



                return View("PedidoConfirmacao", x);

            }

            return View("pedido", pedido);
        }

        // GET: Agendamentos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Agendamentos.Include(a => a.tipoDeAula);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Agendamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Agendamentos == null)
            {
                return NotFound();
            }

            var agendamento = await _context.Agendamentos
                .Include(a => a.tipoDeAula)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agendamento == null)
            {
                return NotFound();
            }

            return View(agendamento);
        }

        // GET: Agendamentos/Create
        public IActionResult Create()
        {
            ViewData["TipoDeAulaId"] = new SelectList(_context.TipoDeAula, "Id", "Id");
            return View();
        }

        // POST: Agendamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cliente,DataInicio,DataFim,DuracaoHoras,DuracaoMinutos,Preco,DataHoraDoPedido,TipoDeAulaId")] Agendamento agendamento)
        {
            ModelState.Remove(nameof(agendamento.tipoDeAula));
            agendamento.DataHoraDoPedido = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Add(agendamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoDeAulaId"] = new SelectList(_context.TipoDeAula, "Id", "Id", agendamento.TipoDeAulaId);
            return View(agendamento);
        }

        // GET: Agendamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Agendamentos == null)
            {
                return NotFound();
            }

            var agendamento = await _context.Agendamentos.FindAsync(id);
            if (agendamento == null)
            {
                return NotFound();
            }
            ViewData["TipoDeAulaId"] = new SelectList(_context.TipoDeAula, "Id", "Id", agendamento.TipoDeAulaId);
            return View(agendamento);
        }

        // POST: Agendamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cliente,DataInicio,DataFim,DuracaoHoras,DuracaoMinutos,Preco,DataHoraDoPedido,TipoDeAulaId")] Agendamento agendamento)
        {
            if (id != agendamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agendamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgendamentoExists(agendamento.Id))
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
            ViewData["TipoDeAulaId"] = new SelectList(_context.TipoDeAula, "Id", "Id", agendamento.TipoDeAulaId);
            return View(agendamento);
        }

        // GET: Agendamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Agendamentos == null)
            {
                return NotFound();
            }

            var agendamento = await _context.Agendamentos
                .Include(a => a.tipoDeAula)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agendamento == null)
            {
                return NotFound();
            }

            return View(agendamento);
        }

        // POST: Agendamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Agendamentos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Agendamentos'  is null.");
            }
            var agendamento = await _context.Agendamentos.FindAsync(id);
            if (agendamento != null)
            {
                _context.Agendamentos.Remove(agendamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgendamentoExists(int id)
        {
            return _context.Agendamentos.Any(e => e.Id == id);
        }
    }
}
