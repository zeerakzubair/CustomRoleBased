using CustomRoleBased.Data;
using CustomRoleBased.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomRoleBased.Controllers
{
    public class PagesController : Controller
    {
        private readonly CustomRoleBasedDbContext dbContext;
        private readonly CustomeRoleManager roleManager;
        public PagesController(CustomRoleBasedDbContext dbContext, CustomeRoleManager roleManager)
        {
            this.dbContext = dbContext;
            this.roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Page(int id)
        {
            var page = dbContext.Pages.Find(id);
            var roleId = roleManager.RoleId;
            var pageRole = dbContext.RolePermissions.FirstOrDefault(x => x.RoleId == roleId && x.PageId == id);
            if(pageRole == null)
            {
                return View("Error", new ErrorViewModel() { ControllerName = "PagesController", ActionName = "Page", ErrorMessage = "You do not have permission to view this kindly login with proper credentials." });
            }
            else
            {
                return View(page);
            }
            
        }

    }
}
