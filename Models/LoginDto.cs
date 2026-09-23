using System.ComponentModel.DataAnnotations;

namespace DotNetGameInventoryAPI.Models;

public class LoginDto
{
    [Required]
    [StringLength(20, MinimumLength = 3)]
    public string Username { get; set; }
    
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Password { get; set; }
}