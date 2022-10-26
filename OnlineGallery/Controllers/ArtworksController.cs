using Microsoft.AspNetCore.Mvc;
using OnlineGallery.Model;

namespace OnlineGallery.Controllers
{
    public class ArtworksController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
                //Check if a user is logged in
                    //If is, store ID
                    //Else, store as annonymus

                model.DateCreated = DateTime.Now;

                //Save model to database

                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
