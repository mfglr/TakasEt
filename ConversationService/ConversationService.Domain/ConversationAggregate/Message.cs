﻿using ConversationService.Domain.UserConnectionAggregate;
using SharedLibrary.Entities;
using SharedLibrary.Exceptions;
using SharedLibrary.Extentions;
using SharedLibrary.ValueObjects;
using System.Net;

namespace ConversationService.Domain.ConversationAggregate
{
    public class Message : Entity<string>, ILikeableByUsers<MessageUserLiking,Guid>
    {
        public string Content { get; private set; }
        public string NormalizeContent { get; private set; }
        public int NumberOfImages { get; private set; }
        public Guid SenderId { get; private set; }
        public Guid ReceiverId { get; private set; }
        public UserConnection Sender { get; }

        public Message(string id,Guid senderId,Guid receiverId, string content,DateTime sendDate)
        {
            Id = id; 
            SenderId = senderId;
            ReceiverId = receiverId;
            Content = content;
            SendDate = sendDate;
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

        public MessageState MessageState { get; private set; }
        public DateTime SendDate { get; private set; }
        public DateTime? ReceivedDate { get; private set; }
        public DateTime? ViewedDate { get; private set; }

        public void MarkAsCreated()
        {
            if (MessageState == MessageState.Created || MessageState == MessageState.Received || MessageState == MessageState.Viewed)
                return;
            MessageState = MessageState.CreateMessageState(MessageState.Created);
        }
        public void MarkAsReceived(DateTime receivedDate)
        {
            if (MessageState == MessageState.Received || MessageState == MessageState.Viewed)
                return;
            MessageState = MessageState.CreateMessageState(MessageState.Received);
            ReceivedDate = receivedDate;
        }
        public void MarkAsViewed(DateTime viewedDate)
        {
            if (MessageState == MessageState.Viewed)
                return;
            MessageState = MessageState.CreateMessageState(MessageState.Viewed);
            ViewedDate = viewedDate;
        }

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
