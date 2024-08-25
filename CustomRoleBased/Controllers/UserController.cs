using CustomRoleBased.Data;
using CustomRoleBased.Models;
using CustomRoleBased.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.CompilerServices;


namespace CustomRoleBased.Controllers
{
    public class UserController : Controller
    {
        private readonly CustomRoleBasedDbContext dbContext;

        private readonly CustomeRoleManager roleManger;
        public UserController(CustomRoleBasedDbContext dbContext, CustomeRoleManager roleManger)
        {
            this.dbContext = dbContext;
            this.roleManger = roleManger;
        }

        public IActionResult Index()
        {
            var users = dbContext.Users.ToList();
            return View(users);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            var userInDb = dbContext.Users.FirstOrDefault(x => x.Email == user.Email);
            if (userInDb == null)
            {
                return View("Error", new ErrorViewModel() { ControllerName = "UserController", ActionName = "Login", ErrorMessage = "Wrong email user not found." });

            }
            else
            {
                if (userInDb.Password == user.Password)
                {
                    var userRole = dbContext.UserRoles.FirstOrDefault(x => x.UserId == userInDb.Id);

                    roleManger.UserId = userRole.UserId;
                    roleManger.RoleId = userRole.RoleId;

                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error", new ErrorViewModel() { ControllerName = "UserController", ActionName = "Login", ErrorMessage = "Wrong password login failed." });
                }
            }

        }

        [HttpGet]
        public IActionResult UserRoles()
        {
            var roles = dbContext.Roles.ToList();
            var pages = dbContext.Pages.ToList();
            var addRolePermissions = new AddRolePermissionsViewModel()
            {
                Roles = roles.Select(i => new SelectListItem
                {
                    Value = i.Id.ToString(),
                    Text = i.Name
                }).ToList(),
                Pages = pages.Select(i => new SelectListItem
                {
                    Value = i.Id.ToString(),
                    Text = i.Name
                }).ToList()
            };

            return View(addRolePermissions);
        }

        [HttpPost]
        public IActionResult UserRoles(AddRolePermissionsViewModel viewModel)
        {
            var rolePermissionExist = dbContext.RolePermissions
                .FirstOrDefault(x => x.RoleId == viewModel.RoleId
                && x.PageId == viewModel.PageId);

            if (rolePermissionExist == null)
            {
                var rolePermission = new RolePermission()
                {
                    RoleId = viewModel.RoleId,
                    PageId = viewModel.PageId
                };

                dbContext.RolePermissions.Add(rolePermission);
                dbContext.SaveChanges();
            }
            else
            {
                return View("Error", new ErrorViewModel() { ControllerName = "UserController", ActionName = "UserRoles", ErrorMessage = "This permission already exits." });

            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ViewRolePermissions()
        {
            var rolePermissions = dbContext.RolePermissions.ToList();
            var viewModelList = new List<RolePermissionsViewModel>();

            foreach (var rolePermission in rolePermissions)
            {
                var role = dbContext.Roles.Find(rolePermission.RoleId);
                var page = dbContext.Pages.Find(rolePermission.PageId);
                var viewModel = new RolePermissionsViewModel()
                {
                    Id = rolePermission.Id,
                    PageId = rolePermission.PageId,
                    PageName = page.Name,
                    RoleId = rolePermission.RoleId,
                    RoleName = role.Name
                };

                viewModelList.Add(viewModel);
            }

            return View(viewModelList);
        }

        public IActionResult DeletePermission(int rolePermssionId)
        {
            var rolePermission = dbContext.RolePermissions.Find(rolePermssionId);

            if(rolePermission != null)
            {
                dbContext.RolePermissions.Remove(rolePermission);
            }

            return RedirectToAction("ViewRolePermissions");
        }
    }
}
