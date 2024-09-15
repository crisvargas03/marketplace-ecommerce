namespace marketplaceAPI.DAL.Models
{
    public class UserRole : BaseEntity<int>
    {
        public string RoleName { get; set; } = string.Empty;

        public virtual ICollection<User>? User { get; set; }
    }
}
