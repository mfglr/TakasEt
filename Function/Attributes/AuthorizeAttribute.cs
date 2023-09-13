using System.Linq;

namespace Function.Attributes
{
	public class AuthorizeAttribute : Attribute
	{

        private readonly List<string> _roles = new List<string>();
        
        public AuthorizeAttribute()
        {
            
        }
        public AuthorizeAttribute(params string[] roles)
        {
            for (int i = 0; i < roles.Length; i++)
                _roles.AddRange(roles);
        }

        public bool HasRole(IEnumerable<string>? roles)
        {
            if (roles == null) return false;
            foreach(var role in roles)
                if (_roles.Contains(role))
                    return true;
            return false;
        }
    }
}
