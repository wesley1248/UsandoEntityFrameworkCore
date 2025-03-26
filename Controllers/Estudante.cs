using AulaEntity.Data;
using AulaEntity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AulaEntity.Controllers
{
    public class Estudante : Controller
    {

        #region "PROPRIEDADES"

        private readonly AppDbContext _context;

        public Estudante(AppDbContext context)
        {
            _context = context;
        }

        #endregion

        public async Task<IActionResult> Index()
        {
            var estudantes = await _context.Estudantes.ToListAsync();
            return View(estudantes);
        }

        public async Task<JsonResult> NewEstudante()
        {
            var estudante = new Models.Estudante();

            _context.Estudantes.Add(estudante);

            int linhasAfetadas = await _context.SaveChangesAsync();

            return Json(new { status = "success", message = "Operação realizada com sucesso" });
        }
    }
}
