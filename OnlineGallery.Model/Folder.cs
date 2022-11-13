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

        [Required]
        public string Name { get; set; }

        public string? CreatedById { get; set; }
        public virtual AppUser? CreatedByUser { get; set; }

        public DateTime? CreatedDate { get; set; }

        public virtual List<UserArtwork>? Artworks { get; set; }
    }
}
