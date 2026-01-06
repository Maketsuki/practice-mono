using LoginSystem.Data;
using LoginSystem.Models;

namespace LoginSystem.Services;

public class AuditService
{
    private readonly ApplicationDbContext _context;

    public AuditService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task LogAsync(string? userId, string action, string? ipAddress, string? details, string? userAgent, string? traceId)
    {
        var log = new AuditLog
        {
            UserId = userId,
            Action = action,
            IPAddress = ipAddress,
            Details = details,
            UserAgent = userAgent,
            TraceId = traceId,
            Timestamp = DateTime.UtcNow
        };

        _context.AuditLogs.Add(log);
        await _context.SaveChangesAsync();
    }
}
