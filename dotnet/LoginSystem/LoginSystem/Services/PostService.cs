using Microsoft.EntityFrameworkCore;
using LoginSystem.Data;
using LoginSystem.Models;

namespace LoginSystem.Services;

public class PostService(ApplicationDbContext dbContext)
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<List<Post>> GetAllPostsAsync()
    {
        Console.WriteLine("DEBUG: GetAllPostsAsync called");
        var posts = await _dbContext.Posts
            .Include(p => p.Author)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();
        Console.WriteLine($"DEBUG: GetAllPostsAsync found {posts.Count} posts");
        return posts;
    }

    public async Task<Post?> CreatePostAsync(string title, string content, string authorId)
    {
        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(content))
        {
            return null;
        }

        var post = new Post
        {
            Title = title.Trim(),
            Content = content.Trim(),
            AuthorId = authorId,
            CreatedAt = DateTime.UtcNow
        };

        _dbContext.Posts.Add(post);
        await _dbContext.SaveChangesAsync();
        Console.WriteLine($"DEBUG: Post created with ID {post.Id}");

        // Load the author for the response
        await _dbContext.Entry(post).Reference(p => p.Author).LoadAsync();

        return post;
    }
}
