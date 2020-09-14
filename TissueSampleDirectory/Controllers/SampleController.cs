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
        public ActionResult Index(int id)
        {
            var getCollectionTitle = db.CollectionModel.Where(m => m.Id == id).FirstOrDefault();
            var sampleList = db.SampleModel.OrderBy(m => m.Collection_Title == getCollectionTitle.Title).ToList();
            return View(sampleList);
        }
    }
}