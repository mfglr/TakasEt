using SharedLibrary.Entities;
using SharedLibrary.Extentions;
using SharedLibrary.ValueObjects;

namespace ChatMicroservice.Domain.MessageEntity
{
    public class Message : Entity, ILikeable<MessageUserLiking>, IViewable<MessageUserViewing>, IRemovableByManyUsers<MessageUserRemoving>
    {
		public Guid UserId { get; private set; }
		public string Content { get; private set; }
        public string NormalizeContent { get; private set; }
		public int NumberOfImages { get; private set; }
		public MessageState MessageState { get; private set; }
        
		public Message(Guid userId,string content)
        {
			UserId = userId;
            Content = content;
            NormalizeContent = content.CustomNormalize();
        }
		
		public void SaveMessage() => MessageState = MessageState.Saved;
		public void ArriveMessage() => MessageState = MessageState.Arrived;
		public void ViewMessage() => MessageState = MessageState.Viewed;

		//message images
		private readonly List<MessageImage> _images = new ();
		public IReadOnlyCollection<MessageImage> MessageImages { get; }
		public void AddImage(string blobName, string extention, Dimension dimension)
		{
			_images.Add(new MessageImage(blobName, extention, dimension));
		}
		public void RemoveImage(Guid imageId)
		{
			var image = _images.FirstOrDefault(x => x.Id == imageId);
			if (image == null) throw new Exception("error");
			image.Remove();
		}
		public void DeleteImage(Guid imageId)
		{
			var index = _images.FindIndex(x => x.Id == imageId);
			if(index == -1) throw new Exception("error");
			_images.RemoveAt(index);
		}

		//ILikeable
		private readonly List<MessageUserLiking> _usersWhoLikedTheEntity = new();
		public IReadOnlyCollection<MessageUserLiking> UsersWhoLikedTheEntity => _usersWhoLikedTheEntity;
		public void Like(Guid userId)
		{
			_usersWhoLikedTheEntity.Add(new MessageUserLiking(Id, userId));
		}
		public void Dislike(Guid userId)
		{
			var index = _usersWhoLikedTheEntity.FindIndex(x => x.UserId == userId);
			if(index == -1) throw new Exception("error");
			_usersWhoLikedTheEntity.RemoveAt(index);
		}
		public bool IsLiked(Guid userId)
		{
			return _usersWhoLikedTheEntity.Any(x => x.UserId == userId);
		}

		//IViewable
		public IReadOnlyCollection<MessageUserViewing> UsersWhoViewedTheEntiy => _usersWhoViewedTheEntiy;
		private readonly List<MessageUserViewing> _usersWhoViewedTheEntiy;
		public void View(Guid userId)
		{
			_usersWhoViewedTheEntiy.Add(new MessageUserViewing(Id, userId));
		}
		public bool IsViewed(Guid userId)
		{
			return _usersWhoViewedTheEntiy.Any(x => x.UserId == userId);
		}

		//IRemovableByManyUsers
		private readonly List<MessageUserRemoving> _usersWhoRemovedTheEntity = new();
		public IReadOnlyCollection<MessageUserRemoving> UsersWhoRemovedTheEntity => _usersWhoRemovedTheEntity;
		public void Remove(Guid userId)
		{
			_usersWhoRemovedTheEntity.Add(new MessageUserRemoving(Id, userId));
		}
		public void Reinsert(Guid userId)
		{
			var index = _usersWhoRemovedTheEntity.FindIndex(x => x.UserId == userId);
			if (index == -1) throw new Exception("error");
			_usersWhoRemovedTheEntity.RemoveAt(index);
		}
		public bool IsRemovedByUser(Guid userId)
		{
			return _usersWhoRemovedTheEntity.Any(x => x.UserId == userId);
		}

		//IRemovable
		public override void Remove()
		{
			base.Remove();
			foreach(var item in _usersWhoRemovedTheEntity) item.Remove();
			foreach (var item in _usersWhoLikedTheEntity) item.Remove();
			foreach (var item in _usersWhoViewedTheEntiy) item.Remove();
		}
		public override void Reinsert()
		{
			base.Reinsert();
			foreach (var item in _usersWhoRemovedTheEntity) item.Reinsert();
			foreach (var item in _usersWhoLikedTheEntity) item.Reinsert();
			foreach (var item in _usersWhoViewedTheEntiy) item.Reinsert();
		}

	}
}
