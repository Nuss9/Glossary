using System.ComponentModel.DataAnnotations;

namespace Json.Models;

public class Monster
{
    [Required]
    public string Name { get; set; } = null!;

    [Range(0, 100)]
    public int Legs { get; set; }
}
