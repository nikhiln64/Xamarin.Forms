namespace Byte_Rate.Model_Classes
{
    public class Tips
    {
        public string id { get; set; }
        public long createdAt { get; set; }
        public string text { get; set; }
        public string type { get; set; }
        public string canonicalUrl { get; set; }
        public bool logView { get; set; }
        public int agreeCount { get; set; }
        public int disagreeCount { get; set; }
        public Todo todo { get; set; }
        public User user { get; set; }
    }
}