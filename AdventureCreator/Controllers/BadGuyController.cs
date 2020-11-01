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
    public class BadGuyController : Controller
    {
        // GET: BadGuy
        public BadGuyService CreateBadGuyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var badGuyService = new BadGuyService(userId);

            return badGuyService;
        }

        public ActionResult Index()
        {
            var service = CreateBadGuyService();
            var model = service.BadGuyList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BadGuyCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateBadGuyService();

            if (service.BadGuyCreate(model))
            {
                TempData["SaveResult"] = "Your BadGuy was Succesfully Created";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your BadGuy could not be " +
                "Created");

            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var service = CreateBadGuyService();
            var edit = service.GetBadGuyById(id);
            var model =
                new BadGuyEdit
                {
                    Class = edit.Class,
                    Name = edit.Name,
                    IsBoss = edit.IsBoss,
                    Level = edit.Level,
                    Planet = edit.Planet
                };
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(BadGuyEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateBadGuyService();
            if (service.UpdateBadGuy(model))
            {
                TempData["SaveResult"] = "Your BadGuy was Succesfully Updated";
                service.UpdateBadGuy(model);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your BadGuy Was Not Updated");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateBadGuyService();
            var model = service.GetBadGuyById(id);

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateBadGuyService();
            var model = svc.GetBadGuyById(id);

            return View(model);
        }

        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult DeleteBadGuy(int id)
        {
            var service = CreateBadGuyService();
            var model = service.GetBadGuyById(id);
            if (service.DeleteBadGuy(model.BadGuyId))
            {
                TempData["SaveResult"] = "Your BadGuy Has Been Deleted";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your BadGuy Could not be deleted");
            return View(model);

        }
    }
}