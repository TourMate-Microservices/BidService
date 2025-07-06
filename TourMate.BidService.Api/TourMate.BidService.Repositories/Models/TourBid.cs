using System;
using System.Collections.Generic;

namespace TourMate.BidService.Repositories.Models;

public partial class TourBid
{
    public int TourBidId { get; set; }

    public int AccountId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public int PlaceRequested { get; set; }

    public string Status { get; set; } = null!;

    public string Content { get; set; } = null!;

    public float MaxPrice { get; set; }
}
