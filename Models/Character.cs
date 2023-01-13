namespace EFAPIRelationships.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PublishedBy { get; set; } = string.Empty;
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
