namespace SharedLibrary.Entities
{
    public interface IViewable
    {
        void View();
        bool IsViewed { get; }
        DateTime? ViewedDate { get; }
    }
}
