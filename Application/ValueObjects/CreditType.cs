namespace Application.ValueObjects
{
	public class CreditType
	{
        public int Value { get; private set; }

        private CreditType(int value)
        {
            Value = value;
        }

        public static CreditType Incoming = new CreditType(1);
        public static CreditType Outgoing = new CreditType(-1);
    }
}
