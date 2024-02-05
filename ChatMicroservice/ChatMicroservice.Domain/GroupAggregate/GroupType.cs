using SharedLibrary.ValueObjects;

namespace ChatMicroservice.Domain.GroupAggregate
{
	public class GroupType : ValueObject
	{

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Type;
		}

		public int Type { get; private set; }

		public readonly static GroupType PublicAnnouncement = new () { Type = 0 };
		public readonly static GroupType PrivateAnnouncement = new () { Type = 1 };
		public readonly static GroupType PublicGroup = new () { Type = 2 };
		public readonly static GroupType PrivateGroup = new () { Type = 3 };

		
	}
}
