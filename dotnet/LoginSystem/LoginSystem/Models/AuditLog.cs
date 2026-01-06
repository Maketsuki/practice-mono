using System;
using System.ComponentModel.DataAnnotations;

namespace LoginSystem.Models;

public class AuditLog
{
    public int Id { get; set; }
    public string? UserId { get; set; }
    public required string Action { get; set; }
    public string? IPAddress { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public string? Details { get; set; }
    public string? UserAgent { get; set; }
    public string? TraceId { get; set; }
}
