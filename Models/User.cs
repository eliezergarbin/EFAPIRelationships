namespace EFAPIRelationships.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public List<Character> Characters { get; set; }
    }
}
