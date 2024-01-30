namespace Models.Entities
{
    public class Role : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public Role(string name) => Name = name;
		public void Update(string name ) => Name = name;
        //users
        private readonly List<RoleUser> _users = new();
		public IReadOnlyCollection<RoleUser> Users => _users;
        public void AddUser(int userId) => _users.Add(new RoleUser(Id, userId));
        public void DeleteUser(int userId)
        {
            int index = _users.FindIndex(x => x.UserId == userId);
            _users.RemoveAt(index);
        }

	}
}
