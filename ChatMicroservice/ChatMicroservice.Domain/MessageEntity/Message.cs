using SharedLibrary.Entities;
using SharedLibrary.Extentions;
using SharedLibrary.ValueObjects;

namespace ChatMicroservice.Domain.MessageEntity
{
    public class Message : Entity, ILikeable<MessageUserLiking>, IViewable<MessageUserViewing>, IRemovableByManyUsers<MessageUserRemoving>
    {
		public int SenderId { get; private set; }
		public string Content { get; private set; }
        public string NormalizeContent { get; private set; }
		public int NumberOfImages { get; private set; }
		public MessageState MessageState { get; private set; }
        
		public Message(int senderId,string content)
        {
			SenderId = senderId;
            Content = content;
            NormalizeContent = content.CustomNormalize();

			_images = new();
			_usersWhoLikedTheEntity = new();
			_usersWhoViewedTheEntity = new();
			_usersWhoReceivedTheMessage = new();
			_usersWhoRemovedTheEntity = new();
		}
		
		public void MarkAsSaved() => MessageState = MessageState.Saved;
		public void MarkAsReceived() => MessageState = MessageState.Received;
		public void MarkAsViewed() => MessageState = MessageState.Viewed;

		//message images
		private readonly List<MessageImage> _images;
		public IReadOnlyCollection<MessageImage> MessageImages { get; }
		public void AddImage(string blobName, string extention, Dimension dimension)
		{
			_images.Add(new MessageImage(blobName, extention, dimension));
			NumberOfImages++;
		}
		public void RemoveImage(int imageId)
		{
			var image = _images.FirstOrDefault(x => x.Id == imageId) ?? throw new Exception("error");
			image.Remove();
			NumberOfImages--;
		}
		public void DeleteImage(int imageId)
		{
			var index = _images.FindIndex(x => x.Id == imageId);
			if(index == -1) throw new Exception("error");
			_images.RemoveAt(index);
			NumberOfImages--;
		}

		//ILikeable
		private readonly List<MessageUserLiking> _usersWhoLikedTheEntity;
		public IReadOnlyCollection<MessageUserLiking> UsersWhoLikedTheEntity => _usersWhoLikedTheEntity;
		public void Like(int userId)
		{
			_usersWhoLikedTheEntity.Add(new MessageUserLiking(userId));
		}
		public void Dislike(int userId)
		{
			var index = _usersWhoLikedTheEntity.FindIndex(x => x.UserId == userId);
			if(index == -1) throw new Exception("error");
			_usersWhoLikedTheEntity.RemoveAt(index);
		}
		public bool IsLiked(int userId)
		{
			return _usersWhoLikedTheEntity.Any(x => x.UserId == userId);
		}

		//IViewable
		private readonly List<MessageUserViewing> _usersWhoViewedTheEntity;
		public IReadOnlyCollection<MessageUserViewing> UsersWhoViewedTheEntity => _usersWhoViewedTheEntity;
		public void View(int userId)
		{
			_usersWhoViewedTheEntity.Add(new MessageUserViewing(userId));
		}
		public bool IsViewed(int userId)
		{
			return _usersWhoViewedTheEntity.Any(x => x.UserId == userId);
		}

		//message user receiving
		private readonly List<MessageUserReceiving> _usersWhoReceivedTheMessage;
		public IReadOnlyCollection<MessageUserReceiving> UsersWhoReceivedTheMessage => _usersWhoReceivedTheMessage;
		public void MarkAsReceived(int userId)
		{
			_usersWhoReceivedTheMessage.Add(new MessageUserReceiving(userId));
		}
		public bool IsReceivedBy(int userId)
		{
			return _usersWhoReceivedTheMessage.Any(x => x.UserId == userId);
		}

		//IRemovableByManyUsers
		private readonly List<MessageUserRemoving> _usersWhoRemovedTheEntity;
		public IReadOnlyCollection<MessageUserRemoving> UsersWhoRemovedTheEntity => _usersWhoRemovedTheEntity;
		public void Remove(int userId)
		{
			_usersWhoRemovedTheEntity.Add(new MessageUserRemoving(userId));
		}
		public void Reinsert(int userId)
		{
			var index = _usersWhoRemovedTheEntity.FindIndex(x => x.UserId == userId);
			if (index == -1) throw new Exception("error");
			_usersWhoRemovedTheEntity.RemoveAt(index);
		}
		public bool IsRemovedByUser(int userId)
		{
			return _usersWhoRemovedTheEntity.Any(x => x.UserId == userId);
		}

		//IRemovable
		public override void Remove()
		{
			base.Remove();
			foreach(var item in _usersWhoRemovedTheEntity) item.Remove();
			foreach (var item in _usersWhoLikedTheEntity) item.Remove();
			foreach (var item in _usersWhoViewedTheEntity) item.Remove();
		}
		public override void Reinsert()
		{
			base.Reinsert();
			foreach (var item in _usersWhoRemovedTheEntity) item.Reinsert();
			foreach (var item in _usersWhoLikedTheEntity) item.Reinsert();
			foreach (var item in _usersWhoViewedTheEntity) item.Reinsert();
		}

	}
}
