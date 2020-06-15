using Forum.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Forum.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagQuestion> TagQuestion { get; set; }
        public DbSet<Answer> Answers { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Question>(q => 
            {
                q.Property(p => p.ViewCount).HasDefaultValue(0);
                q.Property(p => p.CreatedDate).HasDefaultValue(DateTime.Now);
                q.Property(p => p.IsEdited).HasDefaultValue(false);
                q.Property(p => p.RatingPoints).HasDefaultValue(0);
            });


            builder.Entity<Answer>(a => 
            {
                a.Property(p => p.IsAcceptedAnswer).HasDefaultValue(false);
                a.Property(p => p.CreatedDate).HasDefaultValue(DateTime.Now);
                a.Property(p => p.RatingPoints).HasDefaultValue(0);
            });

            builder.Entity<ApplicationUser>(a => 
            {
                a.Property(p => p.RatingPoints).HasDefaultValue(1);
            });

            //configure many-to-many relationship
            builder.Entity<TagQuestion>()
                .HasKey(x => new { x.TagId, x.QuestionId });

            builder.Entity<TagQuestion>()
                .HasOne(tq=>tq.Tag)
                .WithMany(t=>t.TagQuestions)
                .HasForeignKey(pt => pt.TagId);

            builder.Entity<TagQuestion>()
                 .HasOne(tq => tq.Question)
                 .WithMany(t => t.TagQuestions)
                 .HasForeignKey(tq => tq.QuestionId);


            base.OnModelCreating(builder);
        }
    }
}
