namespace OnlineGallery.Models
{
    public class APIArtworkWithPagination
    {
        public Pagination Pagination { get; set; }
        public List<APIArtworkData> Data { get; set; }
        public Info info { get; set; }
        public Config config { get; set; }
    }
}
