using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TissueSampleDirectory.Models;
using PagedList;
using PagedList.Mvc;

namespace TissueSampleDirectory.Controllers
{
    public class CollectionController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Collection
        public ActionResult Index(int? page)
        {
            var collectList = db.CollectionModel.OrderBy(m => m.Id).ToList().ToPagedList(page ?? 1, 6);
           
            return View(collectList);
        }

        // GET: Create
        public ActionResult Create()
        {
            var collectionId = db.CollectionModel.Max(m => m.Collection_Id);
            var model = new CollectionModels();
            model.Collection_Id = collectionId + 1;

            return View(model);
        }

        //POST: Create
        [HttpPost]
        public ActionResult Create(CollectionModels collection, int? page)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            db.CollectionModel.Add(collection);
            db.SaveChanges();
            var collectList = db.CollectionModel.OrderBy(m => m.Id).ToList().ToPagedList(page ?? 1,6);

            return View("Index", collectList);
        }

        // GET: Edit
        public ActionResult Edit(int id)
        {
            var collection = db.CollectionModel.Where(m => m.Id == id).FirstOrDefault();
            var model = new CollectionModels();
            model.Collection_Id = collection.Collection_Id;
            model.Disease_Term = collection.Disease_Term;
            model.Title = collection.Title;

            return View(model);
        }

        // POST: Edit
        [HttpPost]
        public ActionResult Edit(CollectionModels collection, int? page)
        {

            var oldCollection = db.CollectionModel.Where(m => m.Id == collection.Id).FirstOrDefault();
            db.CollectionModel.Remove(oldCollection);
            db.SaveChanges();

            var newCollection = new CollectionModels();
            newCollection.Collection_Id = collection.Collection_Id;
            newCollection.Disease_Term = collection.Disease_Term;
            newCollection.Title = collection.Title;

            db.CollectionModel.Add(newCollection);
            db.SaveChanges();

            var collectList = db.CollectionModel.OrderBy(m => m.Id).ToList().ToPagedList(page ?? 1,6);

            return View("Index", collectList);
        }

        // GET: Delete
        public ActionResult Delete(int id)
        {
            var collection = db.CollectionModel.Where(m => m.Id == id).FirstOrDefault();
            var model = new CollectionModels();
            model.Collection_Id = collection.Collection_Id;
            model.Disease_Term = collection.Disease_Term;
            model.Title = collection.Title;

            return View(model);
        }
        // POST: Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteCollection(int id, int? page)
        {
            var collection = db.CollectionModel.Where(m => m.Id == id).FirstOrDefault();
            db.CollectionModel.Remove(collection);
            db.SaveChanges();

            var orderedList = db.CollectionModel.OrderBy(m => m.Id).ToList().ToPagedList(page ?? 1,6);

            var count = 1;
            foreach(var item in orderedList)
            {
                item.Collection_Id = count;
                db.SaveChanges();
                count++;
            }

            return View("Index", orderedList);
        }

    }
}


