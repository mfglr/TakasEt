using System.Runtime.CompilerServices;

namespace SharedLibrary.Extentions
{
    public static class longExtentions
    {
        public static DateTime ToDateTime(this long timeStamp)
        {
            return new DateTime(1970,1,1,0,0,0,0).AddMilliseconds(timeStamp);
        }
    }
}
