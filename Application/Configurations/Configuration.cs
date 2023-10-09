namespace Application.Configurations
{
	public class Configuration
	{
        public List<Client> Clients { get; set; }
        public CustomTokenOptions CustomTokenOptions { get; set; }
        public Local Local { get; set; }
        public Roles Roles { get; set; }
    }
}
