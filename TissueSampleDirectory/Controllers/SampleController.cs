using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TissueSampleDirectory.Models;

namespace TissueSampleDirectory.Controllers
{
    public class SampleController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sample
        public ActionResult Index(string title)
        {
            var sampleList = db.SampleModel.Where(m => m.Collection_Title == title).ToList();
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
        public ActionResult Create(SampleModels sample, string title)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var getCollectionTitle = db.CollectionModel.Where(m => m.Title == sample.Collection_Title).FirstOrDefault();

            var newSample = new SampleModels();

            newSample.Collection_Title = title;
            newSample.Donor_Count = sample.Donor_Count;
            newSample.Material_Type = sample.Material_Type;
            newSample.Last_Updated = DateTime.Now.ToShortDateString();

            db.SampleModel.Add(newSample);
            db.SaveChanges();

            var sampleList = db.SampleModel.OrderBy(m => m.Id).ToList();
            

            return View("Index", sampleList);
        }
    }
}