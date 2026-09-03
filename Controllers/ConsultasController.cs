using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaGestaoConsultasUVV.Data;
using SistemaGestaoConsultasUVV.Models;

namespace SistemaGestaoConsultasUVV.Controllers;

[Authorize]
public class ConsultasController : Controller
{
    private readonly ApplicationDbContext _context;

    public ConsultasController(ApplicationDbContext context) => _context = context;

    private int UsuarioAtualId => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var consultas = await _context.Consultas
            .Where(c => c.UsuarioId == UsuarioAtualId)
            .OrderBy(c => c.DataHora)
            .ToListAsync();

        return View(consultas);
    }

    [HttpGet]
    public IActionResult Create() => View(new Consulta { DataHora = DateTime.Now.AddHours(1) });

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Consulta consulta)
    {
        if (consulta.DataHora < DateTime.Now)
            ModelState.AddModelError(nameof(consulta.DataHora), "A consulta deve ser agendada para uma data futura.");

        if (!ModelState.IsValid) return View(consulta);

        consulta.UsuarioId = UsuarioAtualId;
        _context.Consultas.Add(consulta);
        await _context.SaveChangesAsync();
        TempData["Mensagem"] = "Consulta cadastrada com sucesso.";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var consulta = await _context.Consultas
            .SingleOrDefaultAsync(c => c.Id == id && c.UsuarioId == UsuarioAtualId);

        return consulta is null ? NotFound() : View(consulta);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Consulta consulta)
    {
        if (id != consulta.Id) return BadRequest();

        if (consulta.DataHora < DateTime.Now)
            ModelState.AddModelError(nameof(consulta.DataHora), "A consulta deve ser agendada para uma data futura.");

        if (!ModelState.IsValid) return View(consulta);

        var existente = await _context.Consultas
            .SingleOrDefaultAsync(c => c.Id == id && c.UsuarioId == UsuarioAtualId);

        if (existente is null) return NotFound();

        existente.Especialidade = consulta.Especialidade;
        existente.DataHora = consulta.DataHora;
        existente.Descricao = consulta.Descricao;
        await _context.SaveChangesAsync();

        TempData["Mensagem"] = "Consulta atualizada com sucesso.";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var consulta = await _context.Consultas
            .SingleOrDefaultAsync(c => c.Id == id && c.UsuarioId == UsuarioAtualId);

        return consulta is null ? NotFound() : View(consulta);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var consulta = await _context.Consultas
            .SingleOrDefaultAsync(c => c.Id == id && c.UsuarioId == UsuarioAtualId);

        if (consulta is null) return NotFound();

        _context.Consultas.Remove(consulta);
        await _context.SaveChangesAsync();
        TempData["Mensagem"] = "Consulta excluída com sucesso.";
        return RedirectToAction(nameof(Index));
    }
}
