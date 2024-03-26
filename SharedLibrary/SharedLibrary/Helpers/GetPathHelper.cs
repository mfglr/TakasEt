using System.Reflection;

namespace SharedLibrary.Helpers
{
    public class GetPathHelper
    {
        public static string Run(string path)
        {
            return $"{Assembly.GetExecutingAssembly().Location}/{path}";
        }
    }
}
