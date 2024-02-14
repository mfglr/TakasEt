namespace SharedLibrary.ValueObjects
{
    public class EmailSubjects : ValueObject
    {

        public string Value { get; private set; }

        public readonly static EmailSubjects EmailConfirmationMail = new() { Value = "Email Confirmation Mail" };

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
