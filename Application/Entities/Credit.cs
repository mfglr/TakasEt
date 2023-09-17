using Application.DomainEventModels;
using Application.ValueObjects;

namespace Application.Entities
{
    public class Credit : Entity
	{
		public User User { get; private set; }
        public decimal SAmount { get; private set; }
		public CreditType CreditType { get; private set; }
		public decimal VAmount { get; private set; }
        
        public Credit(decimal sAmount, CreditType creditType)
		{
			SAmount = sAmount;
			CreditType = creditType;
			VAmount = CreditType.Value * SAmount;
			AddDomainEvent(new CreditDomainEvent(this));
		}
		
	}
}
