using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using TourMate.BidService.Repositories.Models;

namespace TourMate.BidService.Repositories.Context;

public partial class TourMateBidContext : DbContext
{
    public TourMateBidContext()
    {
    }

    public TourMateBidContext(DbContextOptions<TourMateBidContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bid> Bids { get; set; }

    public virtual DbSet<TourBid> TourBids { get; set; }

    public virtual DbSet<TourBidComment> TourBidComments { get; set; }

    public virtual DbSet<UserLikeBid> UserLikeBids { get; set; }

    public static string GetConnectionString(string connectionStringName)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        string connectionString = config.GetConnectionString(connectionStringName);
        return connectionString;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer(GetConnectionString("DefaultConnection"));


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bid>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Bid");

            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.BidId)
                .ValueGeneratedOnAdd()
                .HasColumnName("bidId");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
            entity.Property(e => e.TourBidId).HasColumnName("tourBidId");
            entity.Property(e => e.TourGuideId).HasColumnName("tourGuideId");
        });

        modelBuilder.Entity<TourBid>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TourBid");

            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.MaxPrice).HasColumnName("maxPrice");
            entity.Property(e => e.PlaceRequested).HasColumnName("placeRequested");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .HasColumnName("status");
            entity.Property(e => e.TourBidId)
                .ValueGeneratedOnAdd()
                .HasColumnName("tourBidId");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
        });

        modelBuilder.Entity<TourBidComment>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TourBidComment");

            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.CommentId)
                .ValueGeneratedOnAdd()
                .HasColumnName("commentId");
            entity.Property(e => e.Content)
                .HasMaxLength(255)
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.TourBidId).HasColumnName("tourBidId");
        });

        modelBuilder.Entity<UserLikeBid>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UserLikeBid");

            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.LikeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("likeId");
            entity.Property(e => e.TourBidId).HasColumnName("tourBidId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
