using System;
using System.Collections.Generic;

namespace AlexBlogMVC.Areas.BackEnd.Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public long NewsId { get; set; }

    public string UserName { get; set; } = null!;

    public string? Email { get; set; }

    public string Message { get; set; } = null!;
}
