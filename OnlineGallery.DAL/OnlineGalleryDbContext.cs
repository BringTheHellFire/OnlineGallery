using OnlineGallery.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace OnlineGallery.DAL
{
    public class OnlineGalleryDbContext : IdentityDbContext<AppUser>
    {
        public OnlineGalleryDbContext(DbContextOptions<OnlineGalleryDbContext> options)
            : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<UserArtwork> UserArtworks { get; set; }
        public DbSet<Folder> Folders { get; set; }
    }
}
