namespace Application.Entities
{
	public class Test
	{
        public int Id { get; private set; }
        public int Counter { get; private set; }
		public string Name { get; private set; }

		public Test(int counter,string name) { 
			Counter = counter;
			Name = name;
		}

		public void IncreaseCounter()
		{
			Counter++;
		}

		public void ChangeName()
		{
			Name = Guid.NewGuid().ToString();
		}

		
    }
}
