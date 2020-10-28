using AdventureCreator.Services;
using AdventurerCreator.Models.Adventurer;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventureCreator.Controllers
{
    public class PlanetController : Controller
    {
        // GET: Planet
        public PlanetService CreatePlanetService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var planetService = new PlanetService(userId);

            return planetService;
        }

        public ActionResult Index()
        {
            var service = CreatePlanetService();
            var model = service.PlanetList();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlanetCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePlanetService();

            if(service.PlanetCreate(model))
            {
                TempData["SaveResult"] = "Your Planey was Succesfully Created";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Planet could not be Created");

            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var service = CreatePlanetService();
            var edit = service.GetPlanetById(id);
            var model =
                new PlanetEdit
                {
                    Name = edit.Name,
                    PrimaryColor = edit.PrimaryColor,
                    SecondaryColor = edit.SecondaryColor
                };
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(PlanetEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreatePlanetService();

            if(service.UpdatePlanet(model))
            {
                TempData["SaveResult"] = "Your Planet was Succesfully Updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Planet Was Not Updated");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreatePlanetService();
            var model = service.GetPlanetById(id);

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var service = CreatePlanetService();
            var model = service.GetPlanetById(id);
            if(service.DeletePlanet(model.PlanetId) && model.BadGuys == null)
            {
                TempData["SaveResult"] = "Your Planet Has Been Deleted";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Planet Could not be deleted");
            return View(model);

        }
    }
}