using Common.Extentions;
using Models.ValueObjects;

namespace Models.Entities
{
	public class Group : Entity
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
		public void AddUser(int userId)
		{
			_users.Add(new GroupUser(Id, userId));
		}
		public void DeleteUser(int userId)
		{
			int index = _users.FindIndex(x => x.UserId == userId);
			_users.RemoveAt(index);
		}

		//messages
		private readonly List<Message> _messages = new();
		public IReadOnlyCollection<Message> Messages => _messages;
		public void AddMessage(int userId,string content)  => _messages.Add(new Message(userId,content));
		public void RemoveMessage(int messageId)
		{
			var message = _messages.First(x => x.Id == messageId);
			message.Remove();
		}
		public void RemoveMessageFromUser(int messageId,int removerId)
		{
			
		}
		public void DeleteMessage(int messageId)
		{
			var index = _messages.FindIndex(x => x.Id == messageId);
			_messages.RemoveAt(index);
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
			var index = _images.FindIndex(x => x.Id == imageId);
			_images.RemoveAt(index);
		}
		public void DeleteImage(int imageId)
		{
			var image = _images.First(x => x.Id == imageId);
			_images.Remove(image);
		}
	}
}
