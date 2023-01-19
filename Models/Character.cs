using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace EFAPIRelationships.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PublishedBy { get; set; } = string.Empty;

        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }

        public Weapon Weapon { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
