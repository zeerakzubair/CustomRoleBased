namespace CustomRoleBased.Models
{
    public class RolePermissionsViewModel
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int PageId { get; set; }
        public string PageName { get; set; }
    }
}
