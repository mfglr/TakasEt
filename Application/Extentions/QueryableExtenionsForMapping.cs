using Application.Dtos;
using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Extentions
{
	public static class QueryableExtenionsForMapping
	{


		public static IIncludableQueryable<Post,Tag> IncludePost(this IQueryable<Post> queryable)
		{
			return queryable
				.Include(x => x.User)
				.ThenInclude(x => x.UserImages)
				.Include(x => x.UsersWhoLiked)
				.Include(x => x.Comments)
				.Include(x => x.Category)
				.Include(x => x.PostImages)
				.Include(x => x.Tags)
				.ThenInclude(x => x.Tag);
		}

		public static IIncludableQueryable<User,IReadOnlyCollection<UserImage>> IncludeUser(this IQueryable<User> queryable)
		{
			return queryable
				.Include(x => x.Followers)
				.Include(x => x.Followeds)
				.Include(x => x.UserImages);
		}


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
						CategoryId = x.CategoryId,
						CategoryName = x.Category.Name,
						Title = x.Title,
						Content = x.Content,
						CountOfImages = x.CountOfImages,
						CountOfLikes = x.UsersWhoLiked.Count,
						CountOfComments = x.Comments.Count,
						LikeStatus = x.UsersWhoLiked.Any(l => loggedInUserId != null && l.UserId == loggedInUserId),
						UserImage = x
							.User
							.UserImages
							.Where(x => x.IsActive)
							.Select(
								x => new UserImageResponseDto() {
									Id = x.Id,
									Extention = x.Extention
								}
							)
							.FirstOrDefault(),
						PostImages = x
							.PostImages
							.Select(
								x => new PostImageResponseDto()
								{
									Id = x.Id,
									Extention = x.Extention,
								}
							),
						Tags = x.Tags.Select(pt => pt.Tag.Name)
					}
				) ;
		}
		
		public static IQueryable<CommentResponseDto> ToCommentResponseDto(this IQueryable<Comment> queryable,int? loggedInUserId)
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
					LikeStatus = x.UsersWhoLiked.Any(l => loggedInUserId != null && l.UserId == loggedInUserId),
					UserImage = x
						.User
						.UserImages
						.Where(x => x.IsActive)
						.Select(
							x => new UserImageResponseDto()
							{
								Id = x.Id,
								Extention = x.Extention
							}
						).FirstOrDefault()
				}
			);
		}
	
		public static IQueryable<UserResponseDto> ToUserResponseDto(this IQueryable<User> queryable,int? loggedInUserId)
		{
			return
				queryable.Select(
					x =>
						new UserResponseDto()
						{
							Id = x.Id,
							CreatedDate = x.CreatedDate,
							UpdatedDate = x.UpdatedDate,
							Name = x.Name,
							LastName = x.LastName,
							UserName = x.UserName!,
							Email = x.Email!,
							CountOfPosts = x.CountOfPost,
							CountOfFolloweds = x.Followeds.Count,
							CountOfFollowers = x.Followers.Count,
							IsFollowed = x.Followers.Any(x => loggedInUserId != null && x.FollowerId == loggedInUserId),
							IsFollower = x.Followeds.Any(x => loggedInUserId != null && x.FollowedId == loggedInUserId),
							UserImage = x
								.UserImages
								.Where(x => x.IsActive)
								.Select(
									image => new UserImageResponseDto()
									{
										Id = image.Id,
										Extention = image.Extention
									}
								)
								.FirstOrDefault()
						}
				);

		}
	
	}
}
