namespace CustomRoleBased.Models.Domain
{
    public class RolePermission
    {
        public int Id { get; set; }
        public int RoleId {  get; set; }
        public int PageId { get; set; }
    }
}
