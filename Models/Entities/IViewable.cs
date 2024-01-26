namespace Models.Entities
{
    //Users are able to view viewable entities or check Entities is viewed.
    public interface IViewable<TCrossEntity> where TCrossEntity : CrossEntity
    {
        IReadOnlyCollection<TCrossEntity> UsersWhoViewed { get; }
        void View(int viewerId);
        bool IsViewed(int viewingId); 
    }
}
