namespace SharedLibrary.Entities
{
    public interface IIntegrationEventsContainer
    {
        IReadOnlyCollection<object> Events { get; }
        bool AnyEvent();
        public void ClearAllEvents();
        void AddEvent(object @event);
    }
}
