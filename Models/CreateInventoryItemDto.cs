using System.ComponentModel.DataAnnotations;

namespace DotNetGameInventoryAPI.Models;

public class CreateInventoryItemDto
{
    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string Name { get; set; } = string.Empty;
    [Range(0,999)]
    public int Quantity { get; set; }
}