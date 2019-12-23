using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Zorgcirckel.Models;

namespace Zorgcirckel.Controllers
{
    public class LijstOverzichtController : Controller
    {
        private ZorgCirkelEntities db = new ZorgCirkelEntities();
        // GET: LijstOverzicht
        public ActionResult Index()
        {
            return View();
        }

        // GET: LijstOverzicht/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.LijstResult = db.LijstenBekijken(id);
            return View(id);
        }

        // GET: LijstOverzicht/Create
        public ActionResult Create()
        {
            List<LijstViewModel> model = new List<LijstViewModel>();
            var Vragenlijst = db.LijstenBekijken(1);
            foreach (var item in Vragenlijst)
            {
                var vm = new LijstViewModel();
                vm.LijstID = item.LijstID;
                vm.VraagID = item.VraagID;
                vm.Onderwerp = item.Onderwerp;
                vm.Vraag = item.Vraag;
                vm.VraagType = item.VraagType;
                vm.Antwoord1 = "";
                vm.AspNetUsersID = User.Identity.GetUserId();
                model.Add(vm);
            }
            //ViewBag.UsersID = User.Identity.GetUserId();
            return View(model);
        }

        // POST: LijstOverzicht/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "LijstID,VraagID,Antwoord1,Datum,AspNetUsersID")] antwoord antwoord)
        {
            if (ModelState.IsValid)
            {
                db.antwoord.Add(antwoord);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(antwoord);
        }

        // GET: LijstOverzicht/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LijstOverzicht/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LijstOverzicht/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LijstOverzicht/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
