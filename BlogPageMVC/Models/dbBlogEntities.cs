namespace BlogPageMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class dbBlogEntities : DbContext
    {
        public dbBlogEntities()
            : base("name=dbBlogEntities")

        {
        }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tbCategory> tbCategories { get; set; }
        public virtual DbSet<tbComment> tbComments { get; set; }
        public virtual DbSet<tbPost> tbPosts { get; set; }
        public virtual DbSet<tbPost_Category> tbPost_Category { get; set; }
        public virtual DbSet<tbPost_Tag> tbPost_Tag { get; set; }
        public virtual DbSet<tbTag> tbTags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbCategory>()
                .HasMany(e => e.tbPost_Category)
                .WithOptional(e => e.tbCategory)
                .HasForeignKey(e => e.Category_id);

            modelBuilder.Entity<tbComment>()
                .HasMany(e => e.tbComment1)
                .WithOptional(e => e.tbComment2)
                .HasForeignKey(e => e.Parent_id);

            modelBuilder.Entity<tbPost>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<tbPost>()
                .HasMany(e => e.tbComments)
                .WithOptional(e => e.tbPost)
                .HasForeignKey(e => e.Post_id);

            modelBuilder.Entity<tbPost>()
                .HasMany(e => e.tbPost_Category)
                .WithOptional(e => e.tbPost)
                .HasForeignKey(e => e.Post_id);

            modelBuilder.Entity<tbPost>()
                .HasMany(e => e.tbPost_Tag)
                .WithOptional(e => e.tbPost)
                .HasForeignKey(e => e.Post_id);

            modelBuilder.Entity<tbTag>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<tbTag>()
                .HasMany(e => e.tbPost_Tag)
                .WithOptional(e => e.tbTag)
                .HasForeignKey(e => e.Tag_id);
        }
    }
}
