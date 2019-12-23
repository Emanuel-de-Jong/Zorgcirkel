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
    [Authorize]
    public class IncidentensController : Controller
    {
        private ZorgCirkelEntities db = new ZorgCirkelEntities();

        // GET: Incidentens
        public ActionResult Index()
        {
            var incidenten = db.Incidenten.Include(i => i.AspNetUsers).Include(i => i.AspNetUsers1);
            return View(incidenten.ToList());
        }

        // GET: Incidentens/Create
        public ActionResult Create()
        {
            string UserID = User.Identity.GetUserId();

            var patients = from p in db.AspNetUsers
                           join c in db.Contacten on p.Id equals c.PatientID
                           where c.ContactpersoonID == UserID
                           select p;

            ViewBag.PatientID = new SelectList(patients, "Id", "Email");
            return View();
        }

        // POST: Incidentens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string Incident, DateTime Datum, string PatientID, Incidenten incidenten, DateTime Tijd, HttpPostedFileBase file)
        {
            if (User.IsInRole("Patient"))
            {
                PatientID = User.Identity.GetUserId();
            }

            var user =  User.Identity.GetUserId();

            double Uren = Tijd.Hour;
            double Minuten = Tijd.Minute;

            Datum = Datum.AddHours(Uren);
            Datum = Datum.AddMinutes(Minuten);

            Incidenten incident = new Incidenten()
            {
                PatientID = PatientID,
                Incident = Incident,
                AspNetUsersID = user,
                Datum = Datum
            };

            if (file != null && file.ContentLength > 0)
            {
                var reader = new System.IO.BinaryReader(file.InputStream);
                incident.IncidentFoto = reader.ReadBytes(file.ContentLength);
            }

            db.Incidenten.Add(incident);
            db.SaveChanges();

            ViewBag.PatientID = new SelectList(db.AspNetUsers, "Id", "Email", incidenten.PatientID);
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
