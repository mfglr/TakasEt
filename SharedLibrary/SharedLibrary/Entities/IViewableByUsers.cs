namespace SharedLibrary.Entities
{
	public interface IViewableByUsers<TCrossEntity,TUserId>
		where TCrossEntity : Entity<TUserId>
	{
		IReadOnlyCollection<TCrossEntity> UsersWhoViewedTheEntity { get; }
		void View(TUserId userId);
		bool IsViewed(TUserId userId);
	}

	public interface IViewableByUsers<TCrossEntity> : IViewableByUsers<TCrossEntity,int>
		where TCrossEntity : Entity<int>
    {
	}
}
