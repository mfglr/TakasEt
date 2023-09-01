using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Service
{
	public class SignService
	{

		public SecurityKey GetSymmetricSecurityKey(string key)
		{
			return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
		}
	}
}
