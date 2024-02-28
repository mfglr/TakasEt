namespace SharedLibrary.ValueObjects
{
    public class QueueName : ValueObject
    {
        public string Name { get; private set; }

        public QueueName(string name)
        {
            Name = name;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }

        public readonly static QueueName OnUserAccountCreated_CreateUser_Queue = 
            new("OnUserAccountCreated_CreateUser_Queue");

    }
}
