using AuthService.Core;
using Microsoft.AspNetCore.Identity;
using SharedLibrary;
using SharedLibrary.Entities;
using SharedLibrary.Exceptions;
using System.Net;

namespace AuthService.Domain.UserAggregate
{
    public class User : 
        IdentityUser,
        IEntity<string>,
        IAggregateRoot,
        IViewableByUsers<UserUserViewing,string>
    {
        public DateTime CreatedDate { get; private set; }
        public DateTime? UpdatedDate { get; private set; }
        public void SetCreatedDate() => CreatedDate = DateTime.Now;
        public void SetUpdatedDate() => UpdatedDate = DateTime.Now;

        //IRemovable
        public bool IsRemoved { get; private set; }
        public DateTime? RemovedDate { get; private set; }
        public void Remove()
        {
            IsRemoved = true;
            RemovedDate = DateTime.Now;
        }
        public void Reinsert()
        {
            IsRemoved = false;
            RemovedDate = null;
        }


        private readonly List<UserUserViewing> _usersWhoViewedTheEntity = new();
        public IReadOnlyCollection<UserUserViewing> UsersWhoViewedTheEntity => _usersWhoViewedTheEntity;
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
        //Just use when the blocker delete its account temporarily
        public UserUserBlocking RemoveBlock(string blockerId)
        {
            var record = _usersWhoBlockedTheEntity.FirstOrDefault(x => x.BlockerId == blockerId);
            if (record == null)
                throw new AppException("You are not block the user!", HttpStatusCode.BadRequest);
            if (record.IsRemoved)
                throw new AppException("You are already remove the block!", HttpStatusCode.BadRequest);
            record.Remove();
            return record;
        }

        public void DeleteBlock(string blockerId)
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
    }
}
