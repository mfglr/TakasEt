namespace Models.Entities
{
    //Users are able to view viewable entities or check Entities is viewed.
    public interface IViewable<TCrossEntity,T,V>
        where T : IBaseEntity
        where V : User
        where TCrossEntity : CrossEntity<T,V>
    {
        IReadOnlyCollection<TCrossEntity> UsersWhoViewed { get; }
        void View(int viewerId);
        bool IsViewed(int viewingId); 
    }
}
