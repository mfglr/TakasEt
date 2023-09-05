namespace Application.ValueObjects
{
    public class CreditType
    {
        public int Value { get; private set; }

        public CreditType()
        {
            Value = 0;
        }
        private CreditType(int value)
        {
            Value = value; ;
        }

        public static readonly CreditType Incoming = new CreditType(1);
        public static readonly CreditType Outgoing = new CreditType(-1);
    }
}
