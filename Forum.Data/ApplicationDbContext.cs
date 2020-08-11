using Forum.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Forum.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<PostType> PostTypes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<TagPost> TagPosts { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<UserRatingPointsHistory> RatingPointsHistory { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<VoteType> VoteTypes { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserRatingPointsHistory>(u =>
            {
                u.Property(p => p.AddedTime).HasDefaultValueSql("getdate()");
            });


            

            builder.Entity<Post>(p =>
            {
                p.Property(p => p.ViewCount).HasDefaultValue(0);
                p.Property(p => p.CreatedDate).HasDefaultValueSql("getdate()");
                p.Property(p => p.LastActivityDate).HasDefaultValueSql("getdate()");
                p.Property(p => p.RatingPoints).HasDefaultValue(0);
                p.Property(p => p.AnswersCount).HasDefaultValue(0);
                p.HasOne(x => x.Parent)
                .WithOne(x => x.AcceptedAnswer)
                .HasForeignKey(typeof(Post), "AcceptedAnswerId");
                p.HasOne(x => x.AcceptedAnswer)
                .WithOne(x => x.Parent)
                .HasForeignKey(typeof(Post), "ParentId");

            });


            builder.Entity<ApplicationUser>(a =>
            {
                a.Property(p => p.RatingPoints).HasDefaultValue(1);
                a.Property(p => p.Credits).HasDefaultValue(0);
                a.Property(p => p.ProfileViewCount).HasDefaultValue(0);
                a.Property(p => p.DownVotesCount).HasDefaultValue(0);
                a.Property(p => p.UpVotesCount).HasDefaultValue(0);
            });

            //configure many-to-many relationship
            builder.Entity<TagPost>()
                .HasKey(x => new { x.TagId, x.PostId});

            builder.Entity<TagPost>()
                .HasOne(tq => tq.Tag)
                .WithMany(t => t.TagPosts)
                .HasForeignKey(pt => pt.TagId);

            builder.Entity<TagPost>()
                 .HasOne(tq => tq.Post)
                 .WithMany(t => t.TagPosts)
                 .HasForeignKey(tq => tq.PostId);

            builder.Entity<Tag>()
                .HasIndex(x => new { x.Title, x.Content })
                .IsUnique();


            base.OnModelCreating(builder);
        }
    }
}
