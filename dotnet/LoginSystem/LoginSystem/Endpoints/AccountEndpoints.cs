using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LoginSystem.Models;
using LoginSystem.Services;

namespace LoginSystem.Endpoints;

public static class AccountEndpoints
{
    public static IEndpointRouteBuilder MapAccountEndpoints(this IEndpointRouteBuilder app)
    {
        var accountGroup = app.MapGroup("/account");

        accountGroup.MapPost("/login", async (
            [FromServices] SignInManager<ApplicationUser> signInManager,
            [FromServices] AuditService auditService,
            [FromForm] string email,
            [FromForm] string password,
            HttpContext httpContext) =>
        {
            var result = await signInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                var user = await signInManager.UserManager.FindByEmailAsync(email);
                await auditService.LogAsync(user?.Id, "Login", httpContext.Connection.RemoteIpAddress?.ToString(), "Success", httpContext.Request.Headers.UserAgent, httpContext.TraceIdentifier);
                return Results.Redirect("/");
            }
            if (result.IsLockedOut)
            {
                 var user = await signInManager.UserManager.FindByEmailAsync(email);
                 await auditService.LogAsync(user?.Id, "Lockout", httpContext.Connection.RemoteIpAddress?.ToString(), "Account Locked", httpContext.Request.Headers.UserAgent, httpContext.TraceIdentifier);
                 return Results.Redirect("/lockout");
            }
            // Audit Failure
            await auditService.LogAsync(null, "LoginFailed", httpContext.Connection.RemoteIpAddress?.ToString(), $"Email: {email}", httpContext.Request.Headers.UserAgent, httpContext.TraceIdentifier);
            return Results.Redirect("/login?error=Invalid login attempt.");
        });

        accountGroup.MapPost("/register", async (
            [FromServices] UserManager<ApplicationUser> userManager,
            [FromServices] AuditService auditService,
            [FromForm] string email,
            [FromForm] string password,
            HttpContext httpContext) =>
        {
             var user = new ApplicationUser { UserName = email, Email = email };
             var result = await userManager.CreateAsync(user, password);
             if (result.Succeeded)
             {
                 await auditService.LogAsync(user.Id, "Register", httpContext.Connection.RemoteIpAddress?.ToString(), "Success", httpContext.Request.Headers.UserAgent, httpContext.TraceIdentifier);
                 return Results.Redirect("/login?message=Registration successful");
             }
             // Audit Failure
             await auditService.LogAsync(null, "RegisterFailed", httpContext.Connection.RemoteIpAddress?.ToString(), string.Join(", ", result.Errors.Select(e => e.Description)), httpContext.Request.Headers.UserAgent, httpContext.TraceIdentifier);
             return Results.Redirect("/register?error=Registration failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
        });

        accountGroup.MapPost("/logout", async (
            [FromServices] SignInManager<ApplicationUser> signInManager,
            [FromServices] AuditService auditService,
            HttpContext httpContext) =>
        {
             var userId = signInManager.UserManager.GetUserId(httpContext.User);
             await signInManager.SignOutAsync();
             await auditService.LogAsync(userId, "Logout", httpContext.Connection.RemoteIpAddress?.ToString(), "Success", httpContext.Request.Headers.UserAgent, httpContext.TraceIdentifier);
             return Results.Redirect("/");
        });

        return app;
    }
}
