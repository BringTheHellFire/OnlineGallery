namespace OnlineGallery.Models
{
    public class APIArtworkWithPagination
    {
        public APIArtworkPagination Pagination { get; set; }
        public List<APIArtworkData> Data { get; set; }
        public APIArtworkInfo info { get; set; }
        public APIArtworkConfig config { get; set; }
    }
}
