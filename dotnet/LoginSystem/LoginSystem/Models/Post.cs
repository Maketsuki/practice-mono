using System.ComponentModel.DataAnnotations;

namespace LoginSystem.Models;

public class Post
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;
    
    [Required]
    public string Content { get; set; } = string.Empty;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public string? AuthorId { get; set; }
    
    public ApplicationUser? Author { get; set; }
}
