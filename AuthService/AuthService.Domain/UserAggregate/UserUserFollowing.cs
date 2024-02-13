﻿using SharedLibrary.Entities;

namespace AuthService.Domain.UserAggregate
{
    public class UserUserFollowing : Entity<string>
    {
        public string FollowerId { get; private set; }
        public string FollowingId { get; private set; }

        public UserUserFollowing(string followerId) => FollowerId = followerId;
    }
}
