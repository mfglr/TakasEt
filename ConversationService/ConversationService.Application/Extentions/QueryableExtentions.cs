using ConversationService.Application.Dtos;
using ConversationService.Domain.ConversationAggregate;

namespace ConversationService.Application.Extentions
{
    public static class QueryableExtentions
    {

        public static IQueryable<ConversationResponseDto> ToConversationResponseDto(this IQueryable<Conversation> queryable,Guid loginUserId )
        {
            return queryable
                .Select(x => new ConversationResponseDto()
                {
                    Id = x.Id,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate,
                    DateTimeOfLastMessage = x.DateTimeOfLastMessage,
                    ReceiverId = x.UserId1 == loginUserId ? x.UserId2 : x.UserId1,
                    
                    LastMessage = x
                        .Messages
                        .OrderByDescending(x => x.CreatedDate)
                        .Select(x => new MessageResponseDto()
                        {
                            Id = x.Id,
                            CreatedDate = x.CreatedDate,
                            ReceivedDate = x.ReceivedDate,
                            SendDate = x.SendDate,
                            ViewedDate = x.ViewedDate,
                            ReceiverId = x.ReceiverId,
                            SenderId = x.SenderId,
                            Status = x.MessageState.Status,
                            Content = x.Content,
                            UpdatedDate = x.UpdatedDate,
                            Images = x.Images.Select(x => new MessageImageResponseDto()
                            {
                                Id = x.Id,
                                CreatedDate = x.CreatedDate,
                                Extention = x.Extention,
                                ContainerName = x.ContainerName.Value,
                                BlobName = x.BlobName,
                                AspectRatio = x.Dimension.AspectRatio,
                                Width = x.Dimension.Width,
                                Height = x.Dimension.Height,
                            })
                        })
                        .FirstOrDefault(),
                    
                    NewMessages = x
                        .Messages
                        .OrderByDescending(x => x.SendDate)
                        .Where(x => x.MessageState.Status != MessageState.Viewed.Status)
                        .Select(x => new MessageResponseDto()
                        {
                            Id = x.Id,
                            CreatedDate = x.CreatedDate,
                            ReceiverId = x.ReceiverId,
                            SenderId = x.SenderId,
                            Status = x.MessageState.Status,
                            Content = x.Content,
                            UpdatedDate = x.UpdatedDate,
                            ReceivedDate = x.ReceivedDate,
                            SendDate = x.SendDate,
                            ViewedDate = x.ViewedDate,
                            Images = x.Images.Select(x => new MessageImageResponseDto()
                            {
                                Id = x.Id,
                                CreatedDate = x.CreatedDate,
                                Extention = x.Extention,
                                ContainerName = x.ContainerName.Value,
                                BlobName = x.BlobName,
                                AspectRatio = x.Dimension.AspectRatio,
                                Width = x.Dimension.Width,
                                Height = x.Dimension.Height,
                            })
                        })
                        .ToList()

                });
        }

    }
}
