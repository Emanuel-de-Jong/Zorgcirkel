using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Zorgcirckel.Models;
using Microsoft.AspNet.Identity;

namespace Zorgcirckel.Controllers
{
    [Authorize(Roles = "Patient")]
    public class ContactpersonenController : Controller
    {
        private ZorgCirkelEntities db = new ZorgCirkelEntities();

        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Contactpersonen
        public ActionResult Index()
        {
            var contacten = db.Contacten.Include(c => c.AspNetUsers).Include(c => c.AspNetUsers1);
            return View(contacten.ToList());
        }

        // GET: Contactpersonen/Create
        public ActionResult Create()
        {
            ViewBag.PatientID = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.ContactpersoonID = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Contactpersonen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientID,ContactpersoonID,Relatie,Contactpersoon")] Contacten contacten, string email)
        {
            contacten.PatientID = User.Identity.GetUserId();
            contacten.ContactpersoonID = UserManager.FindByEmail(email).Id;

            if (ModelState.IsValid)
            {
                db.Contacten.Add(contacten);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PatientID = new SelectList(db.AspNetUsers, "Id", "Email", contacten.PatientID);
            ViewBag.ContactpersoonID = new SelectList(db.AspNetUsers, "Id", "Email", contacten.ContactpersoonID);
            return View(contacten);
        }



        public ActionResult ChangeRoles(string ContactpersoonID)
        {
            var rollen = db.AspNetRoles.Where(r => r.Name != "Admin" && r.Name != "Beheerder" && r.Name != "Gebruiker" && r.Name != "Patient");

            ToestemmingenViewModel objToestemmingenViewModel = new ToestemmingenViewModel();
            AspNetUsers Contactpersoon = db.AspNetUsers.Find(ContactpersoonID);
            objToestemmingenViewModel.Contactpersoon = Contactpersoon;
            Session["ContactpersoonID"] = Contactpersoon.Id;

            List<string> rolNamen = new List<string>();

            foreach (var rol in rollen)
            {
                string rolNaam = rol.Name;
                rolNamen.Add(rolNaam);
                bool toestemmen;
                if(UserManager.IsInRole(ContactpersoonID, rol.Name))
                {
                    toestemmen = true;
                }
                else
                {
                    toestemmen = false;
                }
                objToestemmingenViewModel[rolNaam] = toestemmen;
            }

            Session["rolNamen"] = rolNamen;

            Session["Toestemmingen"] = new Dictionary<string, bool>();

            return View(objToestemmingenViewModel);
        }



        public ActionResult ApplyRoles()
        {
            Dictionary<string, bool> Toestemmingen = (Dictionary<string, bool>)Session["Toestemmingen"];

            string ContactpersoonID = (string)Session["ContactpersoonID"];

            foreach (var toestemming in Toestemmingen)
            {
                if (toestemming.Value)
                {
                    UserManager.AddToRole(ContactpersoonID, toestemming.Key);
                }
                else
                {
                    UserManager.RemoveFromRole(ContactpersoonID, toestemming.Key);
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Contactpersonen/Delete/5
        public ActionResult Delete(string ContactpersoonID)
        {
            db.SPVerwijderContactpersoonRij(ContactpersoonID, User.Identity.GetUserId());

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
