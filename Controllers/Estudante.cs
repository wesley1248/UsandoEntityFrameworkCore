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

            if (estudantes.Count == 0)
            {
                return new EmptyResult(); 
            }

            return View(estudantes);
        }

        public async Task<JsonResult> NewEstudante()
        {
            try
            {
                var estudante = new Models.Estudante();
                _context.Estudantes.Add(estudante);
                var linhasAfetadas = await _context.SaveChangesAsync();

                return Json(new { status = linhasAfetadas });
            }
            catch (Exception ex)
            {
                string mensagemErro = ex.InnerException?.Message ?? ex.Message;
                return Json(new { status = 3, message = mensagemErro });
            }
        }

        public async Task<JsonResult> EditarEstudante()
        {
            int linhasAfetadas = 0;

            try
            {
                var primeiroId = await _context.Estudantes
                    .Where(e => e.Nome != "AAA")
                    .Select(e => e.Id)
                    .FirstOrDefaultAsync();

                if (primeiroId != Guid.Empty)
                {
                    linhasAfetadas = await _context.Estudantes
                        .Where(e => e.Id == primeiroId)
                        .ExecuteUpdateAsync(s => s.SetProperty(e => e.Nome, "AAA"));
                }

                return Json(new { status = linhasAfetadas });
            }
            catch (Exception ex)
            {
                string mensagemErro = ex.InnerException?.Message ?? ex.Message;
                return Json(new { status = 3, message = mensagemErro });
            }
        }

        public async Task<JsonResult> ExcluirEstudante()
        {
            int linhasAfetadas = 0;

            try
            {
                var primeiroId = await _context.Estudantes
                    .Where(e => e.Nome != "AAA")
                    .Select(e => e.Id)
                    .FirstOrDefaultAsync();

                if (primeiroId != Guid.Empty)
                {
                    linhasAfetadas = await _context.Estudantes
                        .Where(e => e.Id == primeiroId)
                        .ExecuteDeleteAsync();
                }

                return Json(new { status = linhasAfetadas });
            }
            catch (Exception ex)
            {
                string mensagemErro = ex.InnerException?.Message ?? ex.Message;
                return Json(new { status = 3, message = mensagemErro });
            }
        }
    }
}
