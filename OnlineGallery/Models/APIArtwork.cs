namespace OnlineGallery.Models
{
    public class APIArtwork
    {
        public APIArtworkData Data { get; set; }
        public APIArtworkInfo Info { get; set; }
        public APIArtworkConfig Config { get; set; }

        public APIArtwork()
        {
            Data = new APIArtworkData();
            Info = new APIArtworkInfo();
            Config = new APIArtworkConfig();
        }

        public APIArtwork(APIArtworkData _data, APIArtworkInfo _info, APIArtworkConfig _config)
        {
            Data = _data;
            Info = _info;
            Config = _config;
        }
    }
}
