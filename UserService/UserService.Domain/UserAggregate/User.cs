using SharedLibrary.Entities;
using SharedLibrary.Exceptions;
using SharedLibrary.Extentions;
using SharedLibrary.IntegrationEvents;
using SharedLibrary.ValueObjects;
using System.Net;

namespace UserService.Domain.UserAggregate
{
    public class User :
        Entity<Guid>,
        IAggregateRoot,
        IViewableByUsers<Viewing, Guid>,
        IFollowableByUsers<Following, Guid>,
        IBlockableByUsers<Blocking, Guid>
    {
        public string? Name { get; private set; }
        public string? LastName { get; private set; }
        public string? NormalizedFullName { get; private set; }
        public DateTime? DateOfBirth { get; private set; }
        public bool? Gender { get; private set; }

        public void Update(string? name,string? lastName,DateTime? dateOfBirth,bool? gender) {
            Name = name;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;

            if(name != null && lastName != null)
                NormalizedFullName = $"{name + " " ?? ""}{lastName ?? ""}".CustomNormalize();
        }

        //IRemovable
        public override void Remove()
        {
            base.Remove();

            foreach (var user in UsersWhoViewedTheEntity)
                user.Remove();
            foreach (var user in UsersTheEntityViewed)
                user.Remove();

            foreach (var user in UsersWhoBlockedTheEntity)
                user.Remove();
            foreach (var user in UsersTheEntityBlocked)
                user.Remove();
        }
        public override void Reinsert()
        {
            base.Reinsert();

            IsRemoved = false;
            RemovedDate = null;

            foreach (var user in UsersWhoViewedTheEntity)
                user.Reinsert();
            foreach (var user in UsersTheEntityViewed)
                user.Reinsert();

            foreach (var user in UsersWhoBlockedTheEntity)
                user.Reinsert();
            foreach (var user in UsersTheEntityBlocked)
                user.Reinsert();

        }


        //profile visibility
        public bool IsPrivateProfile { get; private set; }
        public void HideProfile() => IsPrivateProfile = true;
        public void VisibleProfile() => IsPrivateProfile = false;

        
        //user images
        private readonly List<UserImage> _userImages = new ();
        public IReadOnlyCollection<UserImage> UserImages => _userImages;
        public void AddImage(string blobName,string extention,Dimension dimension)
        {
            _userImages.Add(new UserImage(blobName, extention, dimension));
        }
        public void RemoveImage(Guid imageId)
        {
            var image = _userImages.FirstOrDefault(x => x.Id == imageId);
            if(image == null || image.IsRemoved)
                throw new AppException("User image was not found!",HttpStatusCode.NotFound);
            image.Remove();
        }
        public void DeleteImage(Guid imageId)
        {
            var image = _userImages.FirstOrDefault(x => x.Id == imageId);
            if (image == null)
                throw new AppException("User image was not found!", HttpStatusCode.NotFound);
            _userImages.Remove(image);
        }

        //IViewableByUsers
        private readonly List<Viewing> _usersWhoViewedTheEntity = new();
        public IReadOnlyCollection<Viewing> UsersWhoViewedTheEntity => _usersWhoViewedTheEntity;
        public IReadOnlyCollection<Viewing> UsersTheEntityViewed { get; }
        public void View(Guid viewerId)
        {
            if (UsersTheEntityBlocked.Any(x => x.BlockedId == viewerId))
                throw new AppException("You must not view the user!", HttpStatusCode.Forbidden);
            _usersWhoViewedTheEntity.Add(new(viewerId));
        }
        public bool IsViewed(Guid viewerId)
        {
            return _usersWhoViewedTheEntity.Any(x => x.ViewerId == viewerId);
        }

        //IBlockableByUsers
        private readonly List<Blocking> _usersWhoBlockedTheEntity = new();
        public IReadOnlyCollection<Blocking> UsersWhoBlockedTheEntity => _usersWhoBlockedTheEntity;
        public IReadOnlyCollection<Blocking> UsersTheEntityBlocked { get; }
        public Blocking Block(Guid blockerId)
        {
            var record = _usersWhoBlockedTheEntity.FirstOrDefault(x => x.BlockerId == blockerId);
            if (record != null)
            {
                if (!record.IsRemoved)
                    throw new AppException("You are already blocked the user!", HttpStatusCode.BadRequest);
                record.Reinsert();
                return record;
            }
            var blocking = new Blocking(blockerId);
            _usersWhoBlockedTheEntity.Add(blocking);
            return blocking;
        }
        public void RemoveBlock(Guid blockerId)
        {
            var record = _usersWhoBlockedTheEntity.FirstOrDefault(x => x.BlockerId == blockerId);
            if (record == null)
                throw new AppException("You are not blocked the user!", HttpStatusCode.BadRequest);
            _usersWhoBlockedTheEntity.Remove(record);
        }
        public bool IsBlocked(Guid blockerId)
        {
            return _usersWhoBlockedTheEntity.Any(x => x.BlockedId == blockerId);
        }

        //IFollowableByUsers
        private readonly List<Following> _usersWhoFollowedTheEntity = new();
        private readonly List<Following> _usersTheEntityFollowed = new();
        public IReadOnlyCollection<Following> UsersWhoFollowedTheEntity => _usersWhoFollowedTheEntity;
        public IReadOnlyCollection<Following> UsersTheEntityFollowed => _usersTheEntityFollowed;
        public Following Follow(Guid followerId)
        {
            if (UsersTheEntityBlocked.Any(x => x.BlockedId == followerId))
                throw new AppException("You don't have any access", HttpStatusCode.Forbidden);

            if (_usersWhoBlockedTheEntity.Any(x => x.BlockerId == followerId))
                throw new AppException("You musn't make a request to follow user before removing the block!", HttpStatusCode.BadRequest);

            var records = _usersWhoFollowedTheEntity
                .Where(x => x.FollowerId == followerId)
                .OrderByDescending(x => x.CreatedDate)
                .ToList();

            var following = new Following(followerId);

            if (records != null && records.Count > 0)
            {
                var LastRecord = records.First();

                if (LastRecord.State == FollowingState.Pending)
                    throw new AppException("You already make a request to follow the user!", HttpStatusCode.BadRequest);

                else if (LastRecord.State == FollowingState.Approved)
                    throw new AppException("You already follow the user!", HttpStatusCode.BadRequest);
                else
                {
                    if(records.Count > 3)
                        AddIntegrationEvent(
                            new RequesToFollowUser_Created_TooManyRejectedRequests_Event()
                            {
                                RequestedId = Id,
                                RequesterId = followerId
                            }
                        );
                }
            }

            if (IsPrivateProfile)
            {
                following.MakeStatePending();
                AddIntegrationEvent(
                    new RequestToFollowUser_Created_Event()
                    {
                        RequestedId = Id,
                        RequesterId = followerId
                    }
                );
            }
            else
            {
                following.MakeStateApproved();
                AddIntegrationEvent(
                    new User_Followed_Event()
                    {
                        FollowerId = followerId,
                        FollowingId = Id
                    }
                );
            }
            _usersWhoFollowedTheEntity.Add(following);
            return following;
        }
        public void Unfollow(Guid followerId)
        {
        }
        public bool IsFollowing(Guid followerId)
        {
            throw new NotImplementedException();
        }

    }
}
