using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OnlineGalerija.PostgresModels
{
    public partial class postgresDbContext : DbContext
    {
        public postgresDbContext()
        {
        }

        public postgresDbContext(DbContextOptions<postgresDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Hashtag> Hashtags { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostHashtag> PostHashtags { get; set; }
        public virtual DbSet<Reaction> Reactions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserFollower> UserFollowers { get; set; }
        public virtual DbSet<UserReactionComment> UserReactionComments { get; set; }
        public virtual DbSet<UserReactionPost> UserReactionPosts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=online_galerija;Username=postgres;Password=password123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_United Kingdom.1252");

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.Text)
                    .HasMaxLength(400)
                    .HasColumnName("text");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("comment_post_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("comment_user_id_fkey");
            });

            modelBuilder.Entity<Hashtag>(entity =>
            {
                entity.ToTable("hashtag");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Text)
                    .HasMaxLength(255)
                    .HasColumnName("text");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("image");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ImageData).HasColumnName("image_data");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("image_post_id_fkey");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("post");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at");

                entity.Property(e => e.Text)
                    .HasMaxLength(255)
                    .HasColumnName("text");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("date")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("post_user_id_fkey");
            });

            modelBuilder.Entity<PostHashtag>(entity =>
            {
                entity.HasKey(e => new { e.PostId, e.HashtagId })
                    .HasName("post_hashtag_pkey");

                entity.ToTable("post_hashtag");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.HashtagId).HasColumnName("hashtag_id");

                entity.HasOne(d => d.Hashtag)
                    .WithMany(p => p.PostHashtags)
                    .HasForeignKey(d => d.HashtagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("post_hashtag_hashtag_id_fkey");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostHashtags)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("post_hashtag_post_id_fkey");
            });

            modelBuilder.Entity<Reaction>(entity =>
            {
                entity.ToTable("reaction");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ReactionImageData).HasColumnName("reaction_image_data");

                entity.Property(e => e.ReactionName)
                    .HasMaxLength(100)
                    .HasColumnName("reaction_name");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.NameSurname)
                    .HasMaxLength(255)
                    .HasColumnName("name_surname");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(100)
                    .HasColumnName("password_hash");

                entity.Property(e => e.ProfilePhotoData).HasColumnName("profile_photo_data");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("date")
                    .HasColumnName("updated_at");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("users_role_id_fkey");
            });

            modelBuilder.Entity<UserFollower>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.FollowerId })
                    .HasName("user_follower_pkey");

                entity.ToTable("user_follower");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.FollowerId).HasColumnName("follower_id");

                entity.HasOne(d => d.Follower)
                    .WithMany(p => p.UserFollowerFollowers)
                    .HasForeignKey(d => d.FollowerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_follower_follower_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserFollowerUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_follower_user_id_fkey");
            });

            modelBuilder.Entity<UserReactionComment>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.CommentId })
                    .HasName("user_reaction_comment_pkey");

                entity.ToTable("user_reaction_comment");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.Property(e => e.ReactionId).HasColumnName("reaction_id");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.UserReactionComments)
                    .HasForeignKey(d => d.CommentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_reaction_comment_comment_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserReactionComments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_reaction_comment_user_id_fkey");
            });

            modelBuilder.Entity<UserReactionPost>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.PostId })
                    .HasName("user_reaction_post_pkey");

                entity.ToTable("user_reaction_post");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.ReactionId).HasColumnName("reaction_id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.UserReactionPosts)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_reaction_post_post_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserReactionPosts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_reaction_post_user_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
