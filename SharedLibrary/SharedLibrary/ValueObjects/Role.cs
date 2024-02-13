namespace SharedLibrary.ValueObjects
{
    public class Role : ValueObject
    {
        public string Name { get; private  set; }
        
        public readonly static Role Admin = new() { Name = "admin" };
        public readonly static Role User = new() { Name = "user" };
        public readonly static Role Client = new() { Name = "client" };

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return User;
        }
    }
}
