using Application.Dtos;
using Application.Dtos.PostImages;
using Application.Dtos.ProfileImage;
using Application.Entities;

namespace Application.Extentions
{
	public static class QueryableExtenionsForMapping
	{
		public static IQueryable<PostResponseDto> ToPostResponseDto(this IQueryable<Post> queryable,int? loggedInUserId)
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
						LikeStatus = x.UsersWhoLiked.Any(l => loggedInUserId != null && l.UserId == loggedInUserId),
						ProfileImage = x
							.User
							.ProfileImages
							.Where(x => x.IsActive)
							.Select(
								x => new ProfileImageResponseDto() {
									Id = x.Id,
									CreatedDate = x.CreatedDate,
									UpdatedDate = x.UpdatedDate,
									UserId = x.UserId,
									BlobName = x.BlobName,
									ContainerName = x.ContainerName,
									Extention = x.Extention
								}
							)
							.FirstOrDefault(),
						PostImages = x
							.PostImages
							.Select(
								image => new PostImageResponseDto()
								{
									Id = image.Id,
									CreatedDate = image.CreatedDate,
									UpdatedDate = image.UpdatedDate,
									PostId = image.PostId,
									Index = image.Index,
									BlobName = image.BlobName,
									ContainerName = image.ContainerName,
									Extention = image.Extention,
								}
							)
					}
				);
		}
		
		public static IQueryable<CommentResponseDto> ToCommentResponseDto(this IQueryable<Comment> queryable)
		{
			return queryable.Select(
				x => new CommentResponseDto()
				{
					Content = x.Content,
					CountOfChildren = x.Children.Count,
					CreatedDate = x.CreatedDate,
					Id = x.Id,
					PostId = x.PostId,
					ParentId = x.ParentId,
					UpdatedDate = x.UpdatedDate,
					UserId = x.UserId,
					UserName = x.User.UserName!,
					CountOfLikes = x.UsersWhoLiked.Count,
					ProfileImage = x
						.User
						.ProfileImages
						.Where(x => x.IsActive)
						.Select(
							x => new ProfileImageResponseDto()
							{
								Id = x.Id,
								CreatedDate = x.CreatedDate,
								UpdatedDate = x.UpdatedDate,
								UserId = x.UserId,
								BlobName = x.BlobName,
								ContainerName = x.ContainerName,
								Extention = x.Extention
							}
						).FirstOrDefault()
				}
			);
		}
	}
}
