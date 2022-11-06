namespace OnlineGallery.Models
{
    public class APIArtwork
    {
        public APIArtworkData Data { get; set; }
        public Info Info { get; set; }
        public Config Config { get; set; }

        public APIArtwork()
        {
            Data = new APIArtworkData();
            Info = new Info();
            Config = new Config();
        }

        public APIArtwork(APIArtworkData _data, Info _info, Config _config)
        {
            Data = _data;
            Info = _info;
            Config = _config;
        }
    }
}
