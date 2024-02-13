﻿namespace SharedLibrary.Entities
{
    public interface IFollowableByUsers<TCrossEntity,TUserId> where TCrossEntity : IEntity<TUserId>
    {
        IReadOnlyCollection<TCrossEntity> UsersWhoFollowedTheEntity { get; }
        TCrossEntity Follow(TUserId followerId);
        void Unfollow(TUserId followerId);
        bool IsFollowing(TUserId followerId);
    }
}
