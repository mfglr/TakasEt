namespace Models.Entities
{
    //Users are able to like and dislike likeable entities or check Entities are liked or disliked.
    public interface ILikeable<TCrossEntity,T,V>
        where T : IBaseEntity
        where V : User
		where TCrossEntity : CrossEntity<T,V>
    {
        IReadOnlyCollection<TCrossEntity> UsersWhoLiked { get; }
        void Like(int userId);
        void Dislike(int userId);
        bool IsLiked(int userId);
    }
}
