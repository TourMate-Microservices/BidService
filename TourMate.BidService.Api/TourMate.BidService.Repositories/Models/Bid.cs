using System;
using System.Collections.Generic;

namespace TourMate.BidService.Repositories.Models;

public partial class Bid
{
    public int BidId { get; set; }

    public int TourBidId { get; set; }

    public int TourGuideId { get; set; }

    public float Amount { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Comment { get; set; }

    public string Status { get; set; } = null!;
}
