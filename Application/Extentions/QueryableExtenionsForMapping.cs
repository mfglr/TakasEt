using Application.Dtos;
using Application.Entities;

namespace Application.Extentions
{
	public static class QueryableExtenionsForMapping
	{
		public static IQueryable<PostResponseDto> ToPostResponseDto(this IQueryable<Post> queryable)
		{
			return queryable
				.Select(
					x => new PostResponseDto()
					{
						Id = x.Id,
						CreatedDate = x.CreatedDate,
						UpdatedDate = x.UpdatedDate,
						UserId = x.User.Id,
						UserName = x.User.UserName!,
						CategoryName = x.Category.Name,
						Title = x.Title,
						Content = x.Content,
						CountOfImages = x.CountOfImages,
						CountOfLikes = x.UsersWhoLiked.Count,
						CountOfViews = x.UsersWhoViewed.Count,
						CountOfComments = x.Comments.Count,
					}
				);
		}
		
	}
}
