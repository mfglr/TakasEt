namespace Application.ValueObjects
{
	public class RoleType
	{
        public string Name { get; private set; }
        public int Index { get; private set; }

        private RoleType(string name, int index)
		{
			Name = name;
			Index = index;
		}
		public static readonly RoleType User = new RoleType("user",0);
		public static readonly RoleType Client = new RoleType("client",1);
    }
}
