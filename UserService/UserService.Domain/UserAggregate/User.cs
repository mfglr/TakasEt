using SharedLibrary.Entities;
using SharedLibrary.Exceptions;
using SharedLibrary.Extentions;
using SharedLibrary.ValueObjects;
using System.Net;

namespace UserService.Domain.UserAggregate
{
    public class User :
        Entity<Guid>,
        IAggregateRoot,
        IViewableByUsers<Viewing, Guid>,
        IFollowableByUsers<Following, Guid>
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

        public User() { }
        public User(string id) => Id = Guid.Parse(id);

        //IRemovable
        public override void Remove()
        {
            base.Remove();

            foreach (var user in UsersWhoViewedTheEntity)
                user.Remove();
            foreach (var user in UsersTheEntityViewed)
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
        }

        //profile visibility
        public bool IsPrivateProfile { get; private set; }
        public void HideProfile() => IsPrivateProfile = true;
        public void MakeProfileVisible() => IsPrivateProfile = false;
        
        //user images
        private readonly List<UserImage> _images = new ();
        public IReadOnlyCollection<UserImage> Images => _images;
        public void AddImage(string blobName,string extention,Dimension dimension)
        {
            _images.Add(new UserImage(blobName, extention, dimension));
        }
        public void RemoveImage(Guid imageId)
        {
            var image = _images.FirstOrDefault(x => x.Id == imageId);
            if(image == null || image.IsRemoved)
                throw new AppException("User image was not found!",HttpStatusCode.NotFound);
            image.Remove();
        }
        public void DeleteImage(Guid imageId)
        {
            var image = _images.FirstOrDefault(x => x.Id == imageId);
            if (image == null)
                throw new AppException("User image was not found!", HttpStatusCode.NotFound);
            _images.Remove(image);
        }

        //IViewableByUsers
        private readonly List<Viewing> _usersWhoViewedTheEntity = new();
        public IReadOnlyCollection<Viewing> UsersWhoViewedTheEntity => _usersWhoViewedTheEntity;
        public IReadOnlyCollection<Viewing> UsersTheEntityViewed { get; }
        public void View(Guid viewerId)
        {
            _usersWhoViewedTheEntity.Add(new(viewerId));
        }
        public bool IsViewed(Guid viewerId)
        {
            return _usersWhoViewedTheEntity.Any(x => x.ViewerId == viewerId);
        }

        //IFollowableByUsers
        private readonly List<Following> _usersWhoFollowedTheEntity = new();
        private readonly List<Following> _usersTheEntityFollowed = new();
        public IReadOnlyCollection<Following> UsersWhoFollowedTheEntity => _usersWhoFollowedTheEntity;
        public IReadOnlyCollection<Following> UsersTheEntityFollowed => _usersTheEntityFollowed;
        public Following Follow(Guid followerId)
        {
            if (_usersWhoFollowedTheEntity.Any(x => x.FollowerId == followerId))
                throw new AppException("You already follow the user!",HttpStatusCode.BadRequest);
            
            var LastRequest = _usersWhoFollowedTheEntity.OrderByDescending(x => x.CreatedDate).FirstOrDefault();
            if (LastRequest != null && LastRequest.State == FollowingState.Pending)
                throw new AppException(
                    "You already make a request to follow the user!",
                    HttpStatusCode.BadRequest
                );

            var following = new Following(followerId);

            if (IsPrivateProfile)
            {
                following.MarkAsPending();
            }
            else
            {

            }
            _usersWhoFollowedTheEntity.Add(following);
            return following;
        }
        public void Unfollow(Guid followerId)
        {
            var index = _usersWhoFollowedTheEntity.FindIndex(x => x.FollowerId == followerId);
            if (index == -1)
                throw new AppException("You have not followed the user before!", HttpStatusCode.BadRequest);
            _usersWhoFollowedTheEntity.RemoveAt(index);
        }
        public bool IsFollowing(Guid followerId)
        {
            return _usersWhoFollowedTheEntity.Any(x => x.FollowerId == followerId);
        }

    }
}
