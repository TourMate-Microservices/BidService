using System;
using System.Collections.Generic;

namespace TourMate.BidService.Repositories.Models;

public partial class UserLikeBid
{
    public int AccountId { get; set; }

    public int TourBidId { get; set; }

    public int LikeId { get; set; }
}
