namespace Application.ValueObjects
{
	public class FileType
	{
		private string _value;
        private FileType(string value)
        {
            _value = value;
        }


        public static readonly FileType PostImage = new FileType("postImage");
		public static readonly FileType ProfileImage = new FileType("profileImage");
		
		public bool Equal(string value) => _value == value;
		
	}
}
