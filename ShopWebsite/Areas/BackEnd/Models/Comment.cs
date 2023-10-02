namespace ShopWebsite.Areas.BackEnd.Models;

public partial class Comment
{
    public long CommentId { get; set; }

    public long NewsId { get; set; }

    public string UserName { get; set; } = null!;

    public string? Email { get; set; }

    public string Message { get; set; } = null!;
}
