using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineGalerija.PostgresModels
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Posts = new HashSet<Post>();
            UserFollowerFollowers = new HashSet<UserFollower>();
            UserFollowerUsers = new HashSet<UserFollower>();
            UserReactionComments = new HashSet<UserReactionComment>();
            UserReactionPosts = new HashSet<UserReactionPost>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string NameSurname { get; set; }
        public byte[] ProfilePhotoData { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? RoleId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<UserFollower> UserFollowerFollowers { get; set; }
        public virtual ICollection<UserFollower> UserFollowerUsers { get; set; }
        public virtual ICollection<UserReactionComment> UserReactionComments { get; set; }
        public virtual ICollection<UserReactionPost> UserReactionPosts { get; set; }
    }
}
