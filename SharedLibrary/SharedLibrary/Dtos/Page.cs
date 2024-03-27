namespace SharedLibrary.Dtos
{
    public class Page<T> : IPage<T> where T : IComparable<T>
    {
        public int Take { get; set; }
        public T LastValue { get; set; }
        public bool IsDescending { get; set; }
    }
}
