using Microsoft.AspNetCore.Mvc.Rendering;

namespace CustomRoleBased.Models
{
    public class AddRolePermissionsViewModel
    {
        public int RoleId { get; set; }
        public int PageId {  get; set; }
        public List<SelectListItem> Roles { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Pages { get; set; } = new List<SelectListItem>();

    }
}
