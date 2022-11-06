namespace OnlineGallery.Models
{
    public class APIAgentWithPagination
    {
        public Pagination Pagination { get; set; }
        public List<APIAgentData> Data { get; set; }
        public Info Info { get; set; }
        public Config Config { get; set; }
    }
}
