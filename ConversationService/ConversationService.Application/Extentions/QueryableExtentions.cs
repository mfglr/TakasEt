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
                    UserId1 = x.UserId1,
                    UserId2 = x.UserId2,
                    DateTimeOfLastMessageReceived = x.DateTimeOfLastMessageReceived,
                    CountOfMessagesUnviewed = x
                        .Messages
                        .Count(
                            x => 
                                x.MessageState.Status != MessageState.Viewed.Status &&
                                x.SenderId != loginUserId
                        ),
                    LastMessage = x
                        .Messages
                        .OrderByDescending(x => x.CreatedDate)
                        .Select(x => new MessageResponseDto()
                        {
                            Id = x.Id,
                            CreatedDate = x.CreatedDate,
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
                });
        }

    }
}
