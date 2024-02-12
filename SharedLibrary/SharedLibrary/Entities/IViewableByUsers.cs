namespace SharedLibrary.Entities
{
	public interface IViewableByUsers<TCrossEntity,TUserId>
		where TCrossEntity : IEntity<TUserId>
	{
		IReadOnlyCollection<TCrossEntity> UsersWhoViewedTheEntity { get; }
		void View(TUserId userId);
		bool IsViewed(TUserId userId);
	}

	public interface IViewableByUsers<TCrossEntity> : IViewableByUsers<TCrossEntity,int>
		where TCrossEntity : IEntity<int>
    {
	}
}
