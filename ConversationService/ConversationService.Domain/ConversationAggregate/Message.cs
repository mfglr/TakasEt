using ConversationService.Domain.UserConnectionAggregate;
using SharedLibrary.Entities;
using SharedLibrary.Exceptions;
using SharedLibrary.Extentions;
using SharedLibrary.ValueObjects;
using System.Net;

namespace ConversationService.Domain.ConversationAggregate
{
    public class Message : Entity<Guid>, ILikeableByUsers<MessageUserLiking,Guid>
    {
        public Guid ConversationId { get; private set; }
        public string Content { get; private set; }
        public string NormalizeContent { get; private set; }
        public int NumberOfImages { get; private set; }

        public Guid SenderId { get; private set; }
        public UserConnection Sender { get; }

        public Message(Guid senderId, string content)
        {
            SenderId = senderId;
            Content = content;
            NormalizeContent = content.CustomNormalize();
        }

        //message images;
        private readonly List<MessageImage> _images = new();
        public IReadOnlyCollection<MessageImage> Images => _images;
        public void AddImage(string blobName, string extention, Dimension dimension)
        {
            _images.Add(new MessageImage(blobName, extention, dimension));
            NumberOfImages++;
        }

        public MessageState State { get; private set; }
        public void ChangeStateToSaved() => State = MessageState.Saved;
        public void ChangeStateToReceived() => State = MessageState.Received;
        public void ChangeStateToViewed() => State = MessageState.Viewed;

        //ILikeableByUsers
        private readonly List<MessageUserLiking> _usersWhoLikedTheEntity = new();
        public IReadOnlyCollection<MessageUserLiking> UsersWhoLikedTheEntity => _usersWhoLikedTheEntity;
        public void Like(Guid userId)
        {
            if (_usersWhoLikedTheEntity.Any(x => x.UserId == userId))
                throw new AppException("You already liked the message!", HttpStatusCode.BadRequest);
            _usersWhoLikedTheEntity.Add(new MessageUserLiking(userId));
        }
        public void Dislike(Guid userId)
        {
            var index = _usersWhoLikedTheEntity.FindIndex(x => x.UserId == userId);
            if (index == -1)
                throw new AppException("You didn't like the entity before!", HttpStatusCode.BadRequest);
            _usersWhoLikedTheEntity.RemoveAt(index);
        }
        public bool IsLiked(Guid userId)
        {
            return _usersWhoLikedTheEntity.Any(x => x.UserId != userId);
        }
    }
}
