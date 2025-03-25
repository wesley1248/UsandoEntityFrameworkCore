using AulaEntity.Data;
using Microsoft.AspNetCore.Mvc;

namespace AulaEntity.Controllers
{
    public class Estudante : Controller
    {

        #region "PROPRIEDADES"

        private readonly AppDbContext _context;

        #endregion

        public IActionResult Index()
        {
            return View();
        }
    }
}
