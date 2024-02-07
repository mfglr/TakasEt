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
		public string NormalizedName { get; private set; }
		public string Description { get; private set; }

		public Group(string name, string description)
		{
			Name = name;
			Description = description;
			NormalizedName = name.CustomNormalize();
		}

		//GroupType
		public GroupType GroupType { get; private set; }
		public void MakePublicAnnouncement() => GroupType = GroupType.PublicAnnouncement;
		public void MakePrivateAnnouncement() => GroupType = GroupType.PrivateAnnouncement;
		public void MakePublicGroup() => GroupType = GroupType.PublicGroup;
		public void MakePrivateGroup() => GroupType = GroupType.PrivateGroup;

		//users
		private readonly List<GroupUser> _users = new();
		public IReadOnlyCollection<GroupUser> Users => _users;
		public void AddUser(int userId)
		{
			if (_users.Any(x => x.UserId == userId))
				throw new Exception($"User is already a member of Group {Name}!");
			_users.Add(new GroupUser(userId));
		}
		public void AddAdmin(int userId)
		{
			if (_users.Any(x => x.UserId == userId))
				throw new Exception($"User is already a member of Group {Name}!");
			var user = new GroupUser(userId);
			user.MakeAdmin();
			_users.Add(user);
		}
		public void RemoveUser(int userId)
		{
			var user = _users.FirstOrDefault(x => x.UserId == userId);
			if(user == null)
				throw new Exception("error");
			user.Remove();
		}
		public void RemoveUserPermanently(int removerId,int userId)
		{
			var remover = _users.FirstOrDefault(x => x.UserId == removerId);
			if (remover == null)
				throw new Exception($"The user({removerId}) is not a member of the Group {Name}!");
			if (remover.Role != UserRole.Admin)
				throw new Exception($"The user({removerId}) is not admin!");

			var user = _users.FirstOrDefault(x => x.UserId == userId);
			if (user == null)
				throw new Exception($"The user({userId}) is not a member of the Group {Name}!");

			_users.Remove(user);

		}
		public void Leave(int userId)
		{
			var user = _users.FirstOrDefault(x => x.UserId == userId);
			if (user == null) throw new Exception($"You are not a member of group {Name}!");
			_users.Remove(user);
		}
		

		//messages
		private readonly List<Message> _messages = new();
		public IReadOnlyCollection<Message> Messages => _messages;

		private GroupUser ThrowExceptionIfIsNotOwnerId(int userId)
		{
			foreach(var user in _users)
				if (user.UserId == userId)
					return user;
			throw new Exception("error");
		}
		private Message GetMessageOrThrowExceptionIfIsNotExist(int messageId)
		{
			var message = _messages.FirstOrDefault(x => x.Id == messageId);
			return message ?? throw new Exception("error");
		}

		public Message AddMessage(int userId, string content)
		{
			var user = ThrowExceptionIfIsNotOwnerId(userId);

			if(
					(
						GroupType == GroupType.PublicAnnouncement || 
						GroupType == GroupType.PrivateAnnouncement
					)&&
					user.Role != UserRole.Admin
			) throw new Exception("error");
			
			var message = new Message(userId, content);
			_messages.Add(message);
			
			return message;
		}
		public void RemoveMessage(int messageId)
		{
			GetMessageOrThrowExceptionIfIsNotExist(messageId).Remove();
		}
		public void ReinsertMessage(int messageId)
		{
			GetMessageOrThrowExceptionIfIsNotExist(messageId).Reinsert();
		}
		public void RemoveMessageForUser(int messageId, int userId)
		{
			ThrowExceptionIfIsNotOwnerId(userId);
			GetMessageOrThrowExceptionIfIsNotExist(messageId).Remove(userId);
		}
		public void ReinsertMessageForUser(int messageId,int userId)
		{
			ThrowExceptionIfIsNotOwnerId(userId);
			GetMessageOrThrowExceptionIfIsNotExist(messageId).Reinsert(userId);
		}
		public void DeleteMessage(int messageId)
		{
			var message = GetMessageOrThrowExceptionIfIsNotExist(messageId);
			_messages.Remove(message);
		}
		public void LikeMessage(int messageId, int userId)
		{
			ThrowExceptionIfIsNotOwnerId(userId);
			GetMessageOrThrowExceptionIfIsNotExist(messageId).Like(userId);
		}
		public void DislikeMessage(int messageId, int userId)
		{
			ThrowExceptionIfIsNotOwnerId(userId);
			GetMessageOrThrowExceptionIfIsNotExist(messageId).Dislike(userId);
		}
		public bool IsLiked(int messageId, int userId)
		{
			ThrowExceptionIfIsNotOwnerId(userId);
			return GetMessageOrThrowExceptionIfIsNotExist(messageId).IsLiked(userId);
		}
		public void ViewMessage(int messageId, int userId)
		{
			ThrowExceptionIfIsNotOwnerId(userId);
			GetMessageOrThrowExceptionIfIsNotExist(messageId).View(userId);
		}
		public bool IsViewed(int messageId, int userId)
		{
			ThrowExceptionIfIsNotOwnerId(userId);
			return GetMessageOrThrowExceptionIfIsNotExist(messageId).IsViewed(userId);
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
		public void RemoveImage(int imageId)
		{
			var image = _images.FirstOrDefault(x => x.Id == imageId) ?? throw new Exception("error");
			_images.Remove(image);
		}
		public void DeleteImage(int imageId)
		{
			var index = _images.FindIndex(x => x.Id == imageId);
			if (index == -1) throw new Exception("error");
			_images.RemoveAt(index);
		}

		//GroupUserRequestToJoin
		private readonly List<GroupUserRequestToJoin> _usersWhoWantToJoinTheGroup = new ();
		public IReadOnlyCollection<GroupUserRequestToJoin> UsersWhoWantsToJoinTheGroup => _usersWhoWantToJoinTheGroup;
		public GroupUserRequestToJoin MakeRequestToJoin(int idOfUserWhoWantsToJoinGroup)
		{
			if(_users.Any(x => x.UserId == idOfUserWhoWantsToJoinGroup))
				throw new Exception("You are already a member of the group!");
			if (_usersWhoWantToJoinTheGroup.Any(x => x.UserId == idOfUserWhoWantsToJoinGroup && x.State == StateOfGroupJoinRequest.PendingApproval))
				throw new Exception("You have already sent a request to join the group!");

			var request = new GroupUserRequestToJoin(idOfUserWhoWantsToJoinGroup);
			request.MarkAsPendingApproval();
			_usersWhoWantToJoinTheGroup.Add(request);
			return request;
		}
		public GroupUserRequestToJoin ApproveRequestToJoin(int approverId, int idOfUserWhoWantsToJoinGroup)
		{
			if (_users.Any(x => x.UserId == idOfUserWhoWantsToJoinGroup))
				throw new Exception("The user is already a member");

			var request = _usersWhoWantToJoinTheGroup.FirstOrDefault(x => x.UserId == idOfUserWhoWantsToJoinGroup);
			if (request == null)
				throw new Exception("There is no a request!");
			if (request.State == StateOfGroupJoinRequest.Approved)
				throw new Exception("The request is already approved!");
			if (request.State == StateOfGroupJoinRequest.Cancelled)
				throw new Exception("The request is aldready cancelled!");

			var approver = _users.FirstOrDefault(x => x.UserId == approverId);
			if (approver == null)
				throw new Exception("The approver is not a member");
			if (approver.Role != UserRole.Admin)
				throw new Exception("The approver is not an admin");

			request.MarkAsApproved(approverId);
			_users.Add(new GroupUser(idOfUserWhoWantsToJoinGroup));

			return request;
		}
	}
}
