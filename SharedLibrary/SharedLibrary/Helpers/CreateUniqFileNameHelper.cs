namespace SharedLibrary.Helpers
{
    public class CreateUniqFileNameHelper
    {
        public static string Run(string extention)
        {
            return $"{Guid.NewGuid()}_{DateTime.Now.Ticks}_{Guid.NewGuid()}{extention}";
        }
    }
}
