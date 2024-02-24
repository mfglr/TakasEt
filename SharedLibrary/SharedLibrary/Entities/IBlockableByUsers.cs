namespace SharedLibrary.Entities
{
    public interface IBlockableByUsers<TCrossEntity,TUserId> where TCrossEntity : Entity<TUserId>
    {
        public IReadOnlyCollection<TCrossEntity> UsersWhoBlockedTheEntity { get; }
        public void Block(TUserId blockerId);
        public void RemoveBlock(TUserId blockerId);
        public bool IsBlocked(TUserId blockerId);
    }
}
