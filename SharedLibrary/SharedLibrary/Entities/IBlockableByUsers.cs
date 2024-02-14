namespace SharedLibrary.Entities
{
    public interface IBlockableByUsers<TCrossEntity,TUserId> where TCrossEntity : IEntity<TUserId>
    {
        public IReadOnlyCollection<TCrossEntity> UsersWhoBlockedTheEntity { get; }
        public TCrossEntity Block(string blockerId);
        public void RemoveBlock(string blockerId);
        public bool IsBlocked(string blockerId);
    }
}
