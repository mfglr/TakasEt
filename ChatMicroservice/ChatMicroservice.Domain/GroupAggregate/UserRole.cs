using SharedLibrary.ValueObjects;

namespace ChatMicroservice.Domain.GroupAggregate
{
	public class UserRole : ValueObject
	{
		public int Role { get; private set; }

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Role;
		}

		public readonly static UserRole Admin = new UserRole() { Role = 0};
		public readonly static UserRole User = new UserRole() { Role = 1 };

	}
}
