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



        public IActionResult Create(int? folderId)
        {
            ViewBag.folderId = folderId;
            return View();
        }
        [HttpPost]
        public IActionResult Create(UserArtwork model)
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

                return RedirectToAction("Index");
            }
            return View();
        }




        [ActionName(nameof(Edit))]
        public IActionResult Edit(int id)
        {
            var model = this._dbContext.UserArtworks.First(p => p.Id == id);
            if (model.UserId == this._userManager.GetUserId(base.User))
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ActionName(nameof(Edit))]
        public async Task<IActionResult> EditPost(int id)
        {
            var post = this._dbContext.UserArtworks.Single(p => p.Id == id);
            var ok = await this.TryUpdateModelAsync(post);

            if (ok && this.ModelState.IsValid)
            {
                this._dbContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }




        public IActionResult Delete(int id)
        {
            var post = this._dbContext.UserArtworks.Where(p => p.Id == id).First();

            this._dbContext.UserArtworks.Remove(post);
            this._dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult GetFolders()
        {
            var folders = this._dbContext.Folders;
            if (folders.Any())
            {
                return PartialView("_Folders", folders.ToList());
            }
            return PartialView("_Folders");
        }
        [HttpPost]
        public IActionResult GetFolder(int? id)
        {
            var folder = this._dbContext.Folders.Where(p => p.Id == id).First();

            if(folder != null)
            {
                var artworks = this._dbContext.UserArtworks.Where(p => p.FolderId == folder.Id).ToList();

                folder.Artworks = artworks;

                return PartialView("_Folder", folder);
            }

            return PartialView("_Folder");
        }
        public IActionResult AddFolder()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddFolder(Folder model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                //add created by what user id

                this._dbContext.Folders.Add(model);
                this._dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public IActionResult DeleteFolder(int id)
        {
            var folder = this._dbContext.Folders.Where(p => p.Id == id).First();

            this._dbContext.Folders.Remove(folder);
            this._dbContext.SaveChanges();

            return PartialView("_Folders");

        }
    }
}
