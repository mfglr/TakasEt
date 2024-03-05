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
                    ReceiverId = x.ReceiverId,
                    SenderId = x.SenderId,
                    DateTimeOfLastMessageReceived = x.DateTimeOfLastMessageReceived,
                    CountOfMessagesUnviewed = x
                        .Messages
                        .Count(
                            x => 
                                x.State.Status != MessageState.Viewed.Status &&
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
                            Status = x.State.Status,
                            Content = x.Content,
                            UpdatedDate = x.UpdatedDate,
                            ConversationId = x.ConversationId,
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
