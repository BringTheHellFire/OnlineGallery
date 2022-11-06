namespace OnlineGallery.Models
{
    public class APIAgentData
    {
        public int id { get; set; }
        public string api_model { get; set; }
        public string api_link { get; set; }
        public string Title { get; set; }
        public string sort_title { get; set; }
        public List<string> alt_titles { get; set; }
        public bool is_artist { get; set; }
        public int? birth_date { get; set; }
        public int? death_date { get; set; }
        public string description { get; set; }
        public object ulan_id { get; set; }
        public DateTime source_updated_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime timestamp { get; set; }

    }
}
