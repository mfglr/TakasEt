namespace SharedLibrary.Entities
{
    public interface IViewableByUser
    {
        void View();
        bool IsViewed { get; }
        DateTime? ViewedDate { get; }
    }
}
