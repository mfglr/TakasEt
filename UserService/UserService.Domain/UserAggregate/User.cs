using SharedLibrary;
using SharedLibrary.Entities;
using SharedLibrary.Exceptions;
using SharedLibrary.Extentions;
using SharedLibrary.ValueObjects;
using System.Net;

namespace UserService.Domain.UserAggregate
{
    public class User :
        Entity<string>,
        IAggregateRoot,
        IViewableByUsers<UserUserViewing, string>,
        IFollowableByUsers<UserUserFollowing, string>,
        IBlockableByUsers<UserUserBlocking,string>
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

        //user images
        private readonly List<UserImage> _userImages = new ();
        public IReadOnlyCollection<UserImage> UserImages => _userImages;
        public void AddImage(string blobName,string extention,Dimension dimension)
        {
            _userImages.Add(new UserImage(blobName, extention, dimension));
        }
        public void RemoveImage(string imageId)
        {
            var image = _userImages.FirstOrDefault(x => x.Id == imageId);
            if(image == null || image.IsRemoved)
                throw new AppException("User image was not found!",HttpStatusCode.NotFound);
            image.Remove();
        }
        public void DeleteImage(string imageId)
        {
            var image = _userImages.FirstOrDefault(x => x.Id == imageId);
            if (image == null)
                throw new AppException("User image was not found!", HttpStatusCode.NotFound);
            _userImages.Remove(image);
        }

        //IRemovable
        public bool IsRemoved { get; private set; }
        public DateTime? RemovedDate { get; private set; }
        public void Remove()
        {
            IsRemoved = true;
            RemovedDate = DateTime.Now;

            foreach (var user in UsersWhoViewedTheEntity)
                user.Remove();
            foreach(var user in UsersTheEntityViewed)
                user.Remove();
            
            foreach(var user in UsersWhoBlockedTheEntity)
                user.Remove();
            foreach (var user in UsersTheEntityBlocked)
                user.Remove();
        }
        public void Reinsert()
        {
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

        //IViewableByUsers
        private readonly List<UserUserViewing> _usersWhoViewedTheEntity = new();
        public IReadOnlyCollection<UserUserViewing> UsersWhoViewedTheEntity => _usersWhoViewedTheEntity;
        public IReadOnlyCollection<UserUserViewing> UsersTheEntityViewed { get; }
        public void View(string viewerId)
        {
            if (UsersTheEntityBlocked.Any(x => x.BlockedId == viewerId))
                throw new AppException("You must not view the user!", HttpStatusCode.Forbidden);
            _usersWhoViewedTheEntity.Add(new(viewerId));
        }
        public bool IsViewed(string viewerId)
        {
            return _usersWhoViewedTheEntity.Any(x => x.ViewerId == viewerId);
        }

        //IBlockableByUsers
        private readonly List<UserUserBlocking> _usersWhoBlockedTheEntity = new();
        public IReadOnlyCollection<UserUserBlocking> UsersWhoBlockedTheEntity => _usersWhoBlockedTheEntity;
        public IReadOnlyCollection<UserUserBlocking> UsersTheEntityBlocked { get; }
        public UserUserBlocking Block(string blockerId)
        {
            var record = _usersWhoBlockedTheEntity.FirstOrDefault(x => x.BlockerId == blockerId);
            if (record != null)
            {
                if (!record.IsRemoved)
                    throw new AppException("You are already blocked the user!", HttpStatusCode.BadRequest);
                record.Reinsert();
                return record;
            }
            var blocking = new UserUserBlocking(blockerId);
            _usersWhoBlockedTheEntity.Add(blocking);
            return blocking;
        }
        public void RemoveBlock(string blockerId)
        {
            var record = _usersWhoBlockedTheEntity.FirstOrDefault(x => x.BlockerId == blockerId);
            if (record == null)
                throw new AppException("You are not blocked the user!", HttpStatusCode.BadRequest);
            _usersWhoBlockedTheEntity.Remove(record);
        }
        public bool IsBlocked(string blockerId)
        {
            return _usersWhoBlockedTheEntity.Any(x => x.BlockedId == blockerId);
        }

        //IFollowableByUsers
        private readonly List<UserUserFollowing> _usersWhoFollowedTheEntity = new();
        public IReadOnlyCollection<UserUserFollowing> UsersWhoFollowedTheEntity => _usersWhoFollowedTheEntity;
        public IReadOnlyCollection<UserUserFollowing> UsersTheEntityFollowed { get; }
        public UserUserFollowing Follow(string followerId)
        {
            if (UsersTheEntityBlocked.Any(x => x.BlockedId == followerId))
                throw new AppException("You don't have any access", HttpStatusCode.Forbidden);
            
            var record = _usersWhoFollowedTheEntity.FirstOrDefault(x => x.FollowerId == followerId);
            if (record != null && record.IsRemoved)
                throw new AppException("User was not found",HttpStatusCode.NotFound);
            
            if (record != null && !record.IsRemoved)
                throw new AppException("You are already follow the user", HttpStatusCode.BadRequest);
            
            var following = new UserUserFollowing(followerId);
            _usersWhoFollowedTheEntity.Add(following);
            return following;
        }
        public void Unfollow(string followerId)
        {
        }
        public bool IsFollowing(string followerId)
        {
            throw new NotImplementedException();
        }
    }
}
