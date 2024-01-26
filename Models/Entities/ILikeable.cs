namespace Models.Entities
{
    //Users are able to like and dislike likeable entities or check Entities is liked or disliked.
    public interface ILikeable<TCrossEntity> where TCrossEntity : CrossEntity
    {
        IReadOnlyCollection<TCrossEntity> UsersWhoLiked { get; }
        void Like(int userId);
        void Dislike(int userId);
        bool IsLiked(int userId);
    }
}
