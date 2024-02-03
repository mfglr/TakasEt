namespace SharedLibrary.Entities
{
	/* Users are able to like and dislike likeable entities or check Entities are liked or disliked.
	 * A record is added to a cross table, When users like an entity.
	 * 
	 * For example
	 * 
	 *	A user with id 1 like a post with id 1 then the record will be added to [post]UserLiking cross table:
	 *	
	 *	******************************
	 *	[post]UserLiking Table
	 *	[postId] - userId
	 *	*******1 - *****1
	 *	******************************
	 * 
	*/

	public interface IGenericLikeable<TCrossEntity,TUserId> where TCrossEntity : Entity
	{
		IReadOnlyCollection<TCrossEntity> UsersWhoLikedTheEntity { get; }
		void Like(TUserId userId);
		void Dislike(TUserId userId);
		bool IsLiked(TUserId userId);
	}

	public interface ILikeable<TCrossEntity> : IGenericLikeable<TCrossEntity,Guid> where TCrossEntity : Entity
	{
	}

}
