namespace Application.Entities
{
	public class Product : Entity
	{
        public string Name { get; private set; }
		public List<string> Images { get; private set; }
    }
}
