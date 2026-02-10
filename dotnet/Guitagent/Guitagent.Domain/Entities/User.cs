namespace Guitagent.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    
    public ICollection<Routine> Routines { get; set; } = new List<Routine>();
}
