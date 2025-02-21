using System.ComponentModel.DataAnnotations;

public class CreateUserRequest
{   
    [Required]
    [StringLength(3)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MinLength(8)]
    public string Email { get; set; } = string.Empty;

    [Range(1, 80)]
    public int Age { get; set; }
}