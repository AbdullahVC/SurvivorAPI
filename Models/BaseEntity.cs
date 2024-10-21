namespace SurvivorAPI.Models
{
    public class BaseEntity
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
