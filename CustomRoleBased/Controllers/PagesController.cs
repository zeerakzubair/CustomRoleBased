using CustomRoleBased.Data;
using Microsoft.AspNetCore.Mvc;

namespace CustomRoleBased.Controllers
{
    public class PagesController : Controller
    {
        private readonly CustomRoleBasedDbContext dbContext;

        public PagesController(CustomRoleBasedDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Page(int id)
        {
            var page = dbContext.Pages.Find(id);
            return View(page);
        }

    }
}
