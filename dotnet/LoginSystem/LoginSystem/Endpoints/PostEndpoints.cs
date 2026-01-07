using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoginSystem.Data;
using LoginSystem.Models;

namespace LoginSystem.Endpoints;

public static class PostEndpoints
{
    public static IEndpointRouteBuilder MapPostEndpoints(this IEndpointRouteBuilder app)
    {
        var postGroup = app.MapGroup("/api/posts");

        // Get all posts - public endpoint
        postGroup.MapGet("/", async (
            [FromServices] ApplicationDbContext dbContext) =>
        {
            var posts = await dbContext.Posts
                .Include(p => p.Author)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
            
            return Results.Ok(posts);
        });

        // Create a new post - requires authentication
        postGroup.MapPost("/", [Authorize] async (
            [FromServices] ApplicationDbContext dbContext,
            [FromServices] UserManager<ApplicationUser> userManager,
            [FromServices] IHttpContextAccessor httpContextAccessor,
            [FromBody] CreatePostRequest request) =>
        {
            if (string.IsNullOrWhiteSpace(request.Title) || string.IsNullOrWhiteSpace(request.Content))
            {
                return Results.BadRequest("Title and Content are required.");
            }

            var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext!.User);
            if (user == null)
            {
                return Results.Unauthorized();
            }

            var post = new Post
            {
                Title = request.Title,
                Content = request.Content,
                AuthorId = user.Id,
                CreatedAt = DateTime.UtcNow
            };

            dbContext.Posts.Add(post);
            await dbContext.SaveChangesAsync();

            // Load the author for the response
            await dbContext.Entry(post).Reference(p => p.Author).LoadAsync();

            return Results.Created($"/api/posts/{post.Id}", post);
        });

        return app;
    }
}

public record CreatePostRequest(string Title, string Content);
