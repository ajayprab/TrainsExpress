namespace TrainsExpress.Common.Entities
{
    public class Route
    {
        public string From { get; private set; }
        public string To { get; private set; }
        public int TimeTaken { get; private set; }

        public Route(string from, string to, int time)
        {
            From = from;
            To = to;
            TimeTaken = time;
        }
    }
}
