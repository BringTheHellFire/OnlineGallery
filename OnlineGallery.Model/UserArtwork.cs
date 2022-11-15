using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineGallery.Model
{
    public class UserArtwork
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public bool? Anonymus { get; set; }

        public string? UserId { get; set; }
        public virtual AppUser? User { get; set; }

        public int? FolderId { get; set; }
        public virtual Folder? Folder { get; set; }

        public string? ImageName { get; set; }
        public string? ImagePath { get; set; }

        public DateTime? DateCreated { get; set; }

    }
}
