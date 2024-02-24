namespace SharedLibrary.ValueObjects
{
    public class CustomClaimTypes : ValueObject
    {

        public string Value { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public readonly static CustomClaimTypes BlockerUser = new() { Value = "blocker-user" };
        public readonly static CustomClaimTypes BlockedUser = new() { Value = "blocked-user" };
        public readonly static CustomClaimTypes CountOfBlocking = new() { Value = "count-of-blocking" };
        public readonly static CustomClaimTypes ProfileVisibility = new() { Value = "profile-visibility" };
    }
}
