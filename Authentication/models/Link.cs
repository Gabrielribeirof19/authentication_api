namespace Authentication.models
{
    public class Links
    {
        public string url { get; set; }
        public string urlShorted { get; set; }
        public int Id { get; set; }
        public DateTime createdAt { get; set; } = new DateTime();
        public DateTime experationDate { get; set; } = new DateTime();

    }
}