using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobPortalProject;

namespace JobPortalProject.Controllers
{
    [Session]
    public class JobApplicantsController : Controller
    {
        private JobPortalEntities db = new JobPortalEntities(); 
        public static string takeuserid;


        // GET: JobApplicants
        public ActionResult Index()
        {
            return View(db.JobApplicants.ToList());
        }


        public ActionResult Apply()
        {
            takeuserid = (string)Session["UserID"];
            var query = db.JobApplicants.SqlQuery("SELECT * FROM [JobApplicants] WHERE UserId = " + takeuserid).ToList();

            return View(query);
        }



        // GET: JobApplicants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobApplicant jobApplicant = db.JobApplicants.Find(id);
            if (jobApplicant == null)
            {
                return HttpNotFound();
            }
            return View(jobApplicant);
        }

        // GET: JobApplicants/Create
        public ActionResult Create()
        {
            Session["forjobtitle"] = (string)Session["jobtitle"];
            return View();
        }
        
        // POST: JobApplicants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApplicantID,UserId,ApplicantName,JobTitle,CV,Contact,Email")] JobApplicant jobApplicant, HttpPostedFileBase file)
        {
             
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string cvpath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/ApplicantsCV/"), filename);
                    file.SaveAs(cvpath);
                    jobApplicant.CV = file.FileName;
                }
                db.JobApplicants.Add(jobApplicant);
                db.SaveChanges();
                return RedirectToAction("Apply");
            }

            return View(jobApplicant);
        }

        // GET: JobApplicants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobApplicant jobApplicant = db.JobApplicants.Find(id);
            if (jobApplicant == null)
            {
                return HttpNotFound();
            }
            return View(jobApplicant);
        }

        // POST: JobApplicants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApplicantID,UserId,ApplicantName,JobTitle,CV,Contact,Email")] JobApplicant jobApplicant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobApplicant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobApplicant);
        }

        // GET: JobApplicants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobApplicant jobApplicant = db.JobApplicants.Find(id);
            if (jobApplicant == null)
            {
                return HttpNotFound();
            }
            return View(jobApplicant);
        }

        // POST: JobApplicants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobApplicant jobApplicant = db.JobApplicants.Find(id);
            db.JobApplicants.Remove(jobApplicant);
            db.SaveChanges();
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
