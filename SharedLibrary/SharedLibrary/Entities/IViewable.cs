namespace SharedLibrary.Entities
{
	public interface IGenericViewable<TCrossEntity,TUserId>
		where TCrossEntity : Entity
	{
		IReadOnlyCollection<TCrossEntity> UsersWhoViewedTheEntiy { get; }
		void View(TUserId userId);
		bool IsViewed(TUserId userId);
	}

	public interface IViewable<TCrossEntity> : IGenericViewable<TCrossEntity,Guid>
		where TCrossEntity : Entity
	{
	}
}
