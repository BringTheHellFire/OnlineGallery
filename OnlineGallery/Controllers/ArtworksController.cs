using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineGallery.DAL;
using OnlineGallery.Model;

namespace OnlineGallery.Controllers
{
    public class ArtworksController : Controller
    {
        private OnlineGalleryDbContext _dbContext;
        private UserManager<AppUser> _userManager;

        public ArtworksController(OnlineGalleryDbContext dbContext, UserManager<AppUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userArtworks = _dbContext.UserArtworks.ToList();
            return View(userArtworks);
        }

        public IActionResult CreatePost()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatePost(UserArtwork model)
        {
            Console.WriteLine(ModelState.IsValid);
            if (ModelState.IsValid)
            {
                if(_userManager.GetUserId(base.User) != null)
                {
                    model.UserId = _userManager.GetUserId(base.User);
                }
                else
                {
                    model.Anonymus = true;
                }

                model.DateCreated = DateTime.Now;

                this._dbContext.UserArtworks.Add(model);
                this._dbContext.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
