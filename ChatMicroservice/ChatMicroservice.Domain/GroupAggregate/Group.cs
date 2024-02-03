using ChatMicroservice.Domain.MessageEntity;
using SharedLibrary;
using SharedLibrary.Entities;
using SharedLibrary.Extentions;
using SharedLibrary.ValueObjects;

namespace ChatMicroservice.Domain.GroupAggregate
{
	public class Group : Entity, IAggregateRoot
	{

		public string Name { get; private set; }
		public string Description { get; private set; }
		public string NormalizedName { get; private set; }
		
		public Group(string name, string description)
		{
			Name = name;
			Description = description;
			NormalizedName = name.CustomNormalize();
		}

		//users
		private readonly List<GroupUser> _users = new();
		public IReadOnlyCollection<GroupUser> Users => _users;
		public void AddUser(Guid userId)
		{
			_users.Add(new GroupUser(Id, userId));
		}
		public void RemoveUser(Guid userId)
		{
			var user = _users.FirstOrDefault(x => x.UserId == userId);
			if (user == null) throw new Exception("error");
			user.Remove();
		}
		public void DeleteUser(Guid userId)
		{
			int index = _users.FindIndex(x => x.UserId == userId);
			if (index == -1) throw new Exception("error");
			_users.RemoveAt(index);
		}

		//messages
		private readonly List<Message> _messages = new();
		public IReadOnlyCollection<Message> Messages => _messages;

		private void throwExceptionIfIsNotOwnerId(Guid userId)
		{
			foreach(var user in _users)
				if (user.UserId == userId) return;
			throw new Exception("error");
		}
		private Message getMessageOrThrowExceptionIfIsNotExist(Guid messageId)
		{
			var message = _messages.FirstOrDefault(x => x.Id == messageId);
			if (message == null) throw new Exception("error");
			return message;
		}
		
		public void AddMessage(Guid userId,string content)  => _messages.Add(new Message(userId,content));
		public void RemoveMessage(Guid messageId)
		{
			getMessageOrThrowExceptionIfIsNotExist(messageId).Remove();
		}
		public void ReinsertMessage(Guid messageId)
		{
			getMessageOrThrowExceptionIfIsNotExist(messageId).Reinsert();
		}
		public void RemoveMessageForUser(Guid messageId,Guid userId)
		{
			throwExceptionIfIsNotOwnerId(userId);
			getMessageOrThrowExceptionIfIsNotExist(messageId).Remove(userId);
		}
		public void ReinsertMessageForUser(Guid messageId,Guid userId)
		{
			throwExceptionIfIsNotOwnerId(userId);
			getMessageOrThrowExceptionIfIsNotExist(messageId).Reinsert(userId);
		}
		public void DeleteMessage(Guid messageId)
		{
			var message = getMessageOrThrowExceptionIfIsNotExist(messageId);
			_messages.Remove(message);
		}
		public void LikeMessage(Guid messageId,Guid userId)
		{
			throwExceptionIfIsNotOwnerId(userId);
			getMessageOrThrowExceptionIfIsNotExist(messageId).Like(userId);
		}
		public void DislikeMessage(Guid messageId,Guid userId)
		{
			throwExceptionIfIsNotOwnerId(userId);
			getMessageOrThrowExceptionIfIsNotExist(messageId).Dislike(userId);
		}
		public bool IsLiked(Guid messageId,Guid userId)
		{
			throwExceptionIfIsNotOwnerId(userId);
			return getMessageOrThrowExceptionIfIsNotExist(messageId).IsLiked(userId);
		}
		public void ViewMessage(Guid messageId,Guid userId)
		{
			throwExceptionIfIsNotOwnerId(userId);
			getMessageOrThrowExceptionIfIsNotExist(messageId).View(userId);
		}
		public bool IsViewed(Guid messageId,Guid userId)
		{
			throwExceptionIfIsNotOwnerId(userId);
			return getMessageOrThrowExceptionIfIsNotExist(messageId).IsViewed(userId);
		}
		
		//images
		private readonly List<GroupImage> _images = new();
		public IReadOnlyCollection<GroupImage> Images => _images;
		public void AddImage(string blobName,string extention,Dimension dimension)
		{
			var image = new GroupImage(blobName, extention, dimension);
			image.Activate();
			_images.Add(image);
		}
		public void RemoveImage(Guid imageId)
		{
			var image = _images.FirstOrDefault(x => x.Id == imageId);
			if (image == null) throw new Exception("error");
			_images.Remove(image);
		}
		public void DeleteImage(Guid imageId)
		{
			var index = _images.FindIndex(x => x.Id == imageId);
			if (index == -1) throw new Exception("error");
			_images.RemoveAt(index);
		}
	}
}
