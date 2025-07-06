using System;
using System.Collections.Generic;

namespace TourMate.BidService.Repositories.Models;

public partial class TourBidComment
{
    public int CommentId { get; set; }

    public int AccountId { get; set; }

    public int TourBidId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public bool IsDeleted { get; set; }
}
