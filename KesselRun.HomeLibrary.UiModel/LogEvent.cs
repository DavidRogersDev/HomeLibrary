namespace KesselRun.HomeLibrary.UiModel
{
    public class LogEvent
    {
        public string Event { get; set; }

        public override string ToString()
        {
            return Event;
        }
    }
}