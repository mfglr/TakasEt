﻿using ConversationService.Domain.DomainEvents;
using ConversationService.Domain.UserConnectionAggregate;
using SharedLibrary.Entities;
using SharedLibrary.Exceptions;
using SharedLibrary.Extentions;
using System.Net;

namespace ConversationService.Domain.MessageAggregate
{
    public class Message : 
        Entity<string>,
        IAggregateRoot,
        ILikeableByUsers<MessageUserLiking, Guid>
    {
        public string? Content { get; private set; }
        public string? NormalizeContent { get; private set; }
        public int NumberOfImages { get; private set; }
        public Guid SenderId { get; private set; }
        public UserConnection? Sender { get; }
        public Guid ReceiverId { get; private set; }
        public byte[] RowVersion { get; private set; }

        public Message(string id,Guid senderId,Guid receiverId, string? content,DateTime sendDate)
        {
            var trimmedContent = content?.Trim();
            var formattedContent = trimmedContent == string.Empty ? null : trimmedContent;

            Id = id; 
            SenderId = senderId;
            ReceiverId = receiverId;
            Content = formattedContent == string.Empty ? null : formattedContent;
            SendDate = sendDate;
            NormalizeContent = formattedContent?.CustomNormalize();
        }

        //message images;
        private readonly List<MessageImage> _images = new();
        public IReadOnlyCollection<MessageImage> Images => _images;
        public void AddImage(string blobName, string extention,int height,int width)
        {
            _images.Add(new MessageImage(blobName, extention, height,width));
            NumberOfImages++;
        }

        //message state
        public MessageState MessageState { get; private set; }
        public DateTime SendDate { get; private set; }
        public DateTime? ReceivedDate { get; private set; }
        public DateTime? ViewedDate { get; private set; }
        public void MarkAsCreated()
        {
            if (Content == null && NumberOfImages == 0)
                throw new AppException("There is no Content!", HttpStatusCode.BadRequest);

            if (MessageState == MessageState.Created || MessageState == MessageState.Received || MessageState == MessageState.Viewed)
                return;

            MessageState = MessageState.CreateMessageState(MessageState.Created);
            AddDomainEvent(new MessageCreatedDomainEvent() { Message = this });
        }
        public void MarkAsReceived(Guid receiverId,DateTime receivedDate)
        {
            if (receiverId != ReceiverId)
                throw new AppException("No Access!", HttpStatusCode.Forbidden);
            
            if (MessageState == MessageState.Received)
                return;
            
            if (MessageState == MessageState.Viewed)
            {
                if (ReceivedDate == null)
                {
                    ReceivedDate = receivedDate;
                    AddDomainEvent(new MessageMarkedAsReceivedDomainEvent() { Message = this });
                }
                return;
            }

            MessageState = MessageState.CreateMessageState(MessageState.Received);
            ReceivedDate = receivedDate;
            AddDomainEvent(new MessageMarkedAsReceivedDomainEvent() { Message = this });
        }
        public void MarkAsViewed(Guid receiverId, DateTime viewedDate)
        {
            if (receiverId != ReceiverId)
                throw new AppException("No Access!", HttpStatusCode.Forbidden);
            
            if (MessageState == MessageState.Viewed)
                return;

            MessageState = MessageState.CreateMessageState(MessageState.Viewed);
            ViewedDate = viewedDate;

            AddDomainEvent(new MessageMarkedAsViewedDomainEvent() { Message = this });
        }

        //ILikeableByUsers
        private readonly List<MessageUserLiking> _usersWhoLikedTheEntity = new();
        public IReadOnlyCollection<MessageUserLiking> UsersWhoLikedTheEntity => _usersWhoLikedTheEntity;
        public void Like(Guid userId)
        {
            if(userId != SenderId && userId != ReceiverId)
                throw new AppException("No Access!",HttpStatusCode.BadRequest);

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
