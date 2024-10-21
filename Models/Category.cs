namespace SurvivorAPI.Models
{
    public class Category : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Bir kategori birçok yarışmacıya sahip olabilir
        public ICollection<Competitor> Competitors { get; set; }
    }
}
