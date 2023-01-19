using System.Text.Json.Serialization;

namespace EFAPIRelationships.Models
{
    public class Skill
    {
        public  int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public int Damage { get; set; } = 10;

        [JsonIgnore]
        public List<Character> Characters { get; set; }

    }
}
