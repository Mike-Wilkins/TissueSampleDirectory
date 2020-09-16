using PagedList;
using System;
using System.Linq;
using System.Web.Mvc;
using TissueSampleDirectory.Models;

namespace TissueSampleDirectory.Controllers
{
    public class SampleController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sample
        public ActionResult Index(string title, int? page)
        {
            var sampleList = db.SampleModel.Where(m => m.Collection_Title == title).ToList().ToPagedList(page ?? 1, 6);
            ViewBag.CollectionTitle = title;

            return View(sampleList);
        }

        // GET: Create
        public ActionResult Create(string title)
        {
            var model = new SampleModels();
            ViewBag.CollectionTitle = title;
            return View(model);
        }

        // POST: Create
        [HttpPost]
        public ActionResult Create(SampleModels sample, string title, int? page)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            ViewBag.CollectionTitle = title;

            var getCollectionTitle = db.CollectionModel.Where(m => m.Title == sample.Collection_Title).FirstOrDefault();
            var newSample = new SampleModels();

            newSample.Collection_Title = title;
            newSample.Donor_Count = sample.Donor_Count;
            newSample.Material_Type = sample.Material_Type;
            newSample.Last_Updated = DateTime.Now.ToShortDateString();

            db.SampleModel.Add(newSample);
            db.SaveChanges();

            var sampleList = db.SampleModel.Where(m => m.Collection_Title == title).ToList().ToPagedList(page ?? 1, 6);

            return View("Index", sampleList);
        }

        //GET: Edit
        public ActionResult Edit(string title, int id)
        {
            var model = db.SampleModel.Where(m => m.Id == id).FirstOrDefault();
            ViewBag.CollectionTitle = title;

            return View(model);
        }
        // POST: Edit
        [HttpPost]
        public ActionResult Edit(SampleModels sample, string title, int? page)
        {
            ViewBag.CollectionTitle = title;
            var oldSample = db.SampleModel.Where(m => m.Id == sample.Id).FirstOrDefault();

            db.SampleModel.Remove(oldSample);
            db.SaveChanges();

            var newSample = new SampleModels();
            newSample.Collection_Title = title;
            newSample.Donor_Count = sample.Donor_Count;
            newSample.Material_Type = sample.Material_Type;
            newSample.Last_Updated = DateTime.Now.ToShortDateString();

            db.SampleModel.Add(newSample);
            db.SaveChanges();

            var sampleList = db.SampleModel.Where(m => m.Collection_Title == title).ToList().ToPagedList(page ?? 1, 6);

            return View("Index", sampleList);
        }

        // GET: Delete
        public ActionResult Delete(string title, int id)
        {
            ViewBag.CollectionTitle = title;
            var model = db.SampleModel.Where(m => m.Id == id).FirstOrDefault();

            return View(model);
        }
        // POST: Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteSample(string title, int id, int? page)
        {

            ViewBag.CollectionTitle = title;
            var model = db.SampleModel.Where(m => m.Id == id).FirstOrDefault();
            db.SampleModel.Remove(model);
            db.SaveChanges();

            var sampleList = db.SampleModel.Where(m => m.Collection_Title == title).ToList().ToPagedList(page ?? 1, 6);

            return View("Index", sampleList);
        }
    }
}