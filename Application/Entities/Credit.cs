using Application.DomainEventModels;
using Application.ValueObjects;

namespace Application.Entities
{
	public class Credit : Entity
	{
		private static decimal sAmountForNewUsers = 1000;

        public Guid UserId { get; private set; }
		public User User { get; private set; }
        public decimal SAmount { get; private set; }
		public CreditType CreditType { get; private set; }
		public decimal VAmount => CreditType.Value * SAmount;

		public Credit(decimal sAmount, CreditType creditType)
		{
			SAmount = sAmount;
			CreditType = creditType;
		}

		public Credit(Guid userId,decimal sAmount, CreditType creditType)
		{
			UserId = userId;
			SAmount = sAmount;
			CreditType = creditType;
			AddDomainEvent(new CreditDomainEvent(this));
		}

		public static Credit CreatCreditForNewUser() {
			return new Credit(sAmountForNewUsers, CreditType.Incoming);
		}
	}
}
