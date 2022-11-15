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
            return View();
        }

        public IActionResult Create(int? folderId)
        {
            ViewBag.folderId = folderId;
            return View();
        }
        [HttpPost]
        public IActionResult Create(UserArtwork model)
        {
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

                var post = this._dbContext.UserArtworks.OrderByDescending(p => p.Id).First();

                return RedirectToAction("AddImage", new { postID = post.Id });
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
                return RedirectToAction("Index");
            }
            return View();
        }




        public IActionResult Delete(int id)
        {
            var post = this._dbContext.UserArtworks.Where(p => p.Id == id).First();

            if(post.ImagePath != null)
            {
                System.IO.File.Delete(post.ImagePath);
            }
            

            this._dbContext.UserArtworks.Remove(post);
            this._dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult GetFolders()
        {
            var currentUserId = this._userManager.GetUserId(base.User);

            var folders = this._dbContext.Folders.Where(p => p.CreatedById == currentUserId);
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
            return PartialView("_AddFolder");
        }
        [HttpPost]
        public IActionResult AddFolder(Folder model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedById = this._userManager.GetUserId(base.User);
                model.CreatedDate = DateTime.Now;

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

        public IActionResult AddImage(int postId)
        {
            var post = this._dbContext.UserArtworks.Where(p => p.Id == postId).First();
            return View(post);
        }

        public async Task<IActionResult> UploadAttachment(int postId, IFormFile file)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var userId = this._userManager.GetUserId(base.User);

            var user = this._userManager.Users.Where(u => u.Id == userId).First();

            var fileName = user.UserName + DateTime.Today.Date.ToShortDateString() + file.FileName;
            string fileNameWithPath = Path.Combine(path, fileName);

            bool fileExists = System.IO.File.Exists(fileNameWithPath);
            if (fileExists)
            {
                //Do something about it
            }
            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            var artwork = this._dbContext.UserArtworks.Where(p => p.Id == postId).First();

            artwork.ImageName = fileName;
            artwork.ImagePath = fileNameWithPath;

            var ok = await this.TryUpdateModelAsync(artwork);

            if (ok)
            {
                this._dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        public IActionResult Details(int id)
        {
            var post = this._dbContext.UserArtworks.Where(p => p.Id == id).First();

            return View(post);
        }

    }
}
