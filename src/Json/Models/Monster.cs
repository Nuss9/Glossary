using Json.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Json.Models;

[Attributes.Monster]
public class Monster
{
    [Required]
    public string Name { get; set; } = null!;

    [Range(0, 100)]
    public int Legs { get; set; }

    [MonsterType]
    public string Type { get; set; } = null!;

    [MonsterCode]
    public string Code { get; set; } = null!;

    public DateTime Birthday { get; set; }
}
