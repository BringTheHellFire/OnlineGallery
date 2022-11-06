using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineGallery.Model
{
    public class Folder
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<UserArtwork> Artworks { get; set; }
    }
}
