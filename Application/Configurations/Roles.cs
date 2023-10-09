namespace Application.Configurations
{
	public class Roles
	{
        public class Role
        {
			public string Name { get; set; }
			public string Id { get; set; }
		}
		public Role Client { get; set; }
		public Role User { get; set; }
        public Role Admin { get; set; }

    }
}
