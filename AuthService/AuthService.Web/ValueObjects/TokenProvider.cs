using SharedLibrary.ValueObjects;

namespace AuthService.Web
{
    internal class TokenProvider : ValueObject
    {

        public string Name { get; private set; }

        public readonly static TokenProvider RefreshTokenProvider = new TokenProvider() { Name = "refresh_token_provider" };

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}
