using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdventureCreator.Services;
using AdventurerCreator.Models.Adventurer;
using Microsoft.AspNet.Identity;

namespace AdventureCreator.Controllers
{
    public class AdventurerController : Controller
    {
        // GET: Adventurer
        public AdventurerService CreateAdventurerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var adventurerService = new AdventurerService(userId);

            return adventurerService;
        }

        public ActionResult Index()
        {
            var service = CreateAdventurerService();
            var model = service.AdventurerList();
            return View(model);
        }
        
        public ActionResult Create(AdventurerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAdventurerService();
            service.AdventurerCreate(model);
            if (service.AdventurerCreate(model))
            {
                TempData["SaveResult"] = "Your Adventurer was Succesfully Created";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Adventurer could not be " +
                "Created");

            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var service = CreateAdventurerService();
            var edit = service.GetAdventurerById(id);
            var model =
                new AdventurerEdit
                {
                    Name = edit.Name,
                };
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(AdventurerEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateAdventurerService();
            service.UpdateAdventurer(model);
            if (service.UpdateAdventurer(model))
            {
                TempData["SaveResult"] = "Your Adventurer was Succesfully Updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Adventurer Was Not Updated");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateAdventurerService();
            var model = service.GetAdventurerById(id);

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var service = CreateAdventurerService();
            var model = service.GetAdventurerById(id);
            if (service.DeleteAdventurer(model.AdventurerId))
            {
                TempData["SaveResult"] = "Your Adventurer Has Been Deleted";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Adventurer Could not be deleted");
            return View(model);

        }
    }
}