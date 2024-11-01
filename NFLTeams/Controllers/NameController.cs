using Microsoft.AspNetCore.Mvc;
using NFLTeams.Models;
using System.ComponentModel.Design;
using Microsoft.AspNetCore.Http;

namespace NFLTeams.Controllers
{
    public class NameController : Controller
    {


        [HttpGet]
        public ViewResult Index()
        {
            // Retrieve data from session, similar to FavoritesController
            var session = new NFLSession(HttpContext.Session);
            var model = new TeamsViewModel
            {
                ActiveConf = session.GetActiveConf(),
                ActiveDiv = session.GetActiveDiv(),
                Teams = session.GetMyTeams(),
                Username = session.GetName() // Include user's name
            };

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Change(TeamsViewModel model)
        {

                var session = new NFLSession(HttpContext.Session);
                session.SetName(model.Username);

                return RedirectToAction("Index", "Home",
                
                new{
                    ActiveConf = session.GetActiveConf(),
                    ActiveDiv = session.GetActiveDiv()
                });
                
        }
    }
}
