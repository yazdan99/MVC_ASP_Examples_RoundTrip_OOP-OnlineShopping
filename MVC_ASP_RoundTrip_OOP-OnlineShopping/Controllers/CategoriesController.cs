using MVC_ASP_RoundTrip_OOP_OnlineShopping.Models.DomainModels.DTO.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC_ASP_RoundTrip_OOP_OnlineShopping.Controllers
{
    public class CategoriesController : Controller
    {
        #region [- ctor -]
        public CategoriesController()
        {
            Ref_CategoryCrud = new Models.DomainModels.POCO.CategoryCrud();
        }
        #endregion

        #region [- props -]
        public Models.DomainModels.POCO.CategoryCrud Ref_CategoryCrud { get; set; }
        #endregion

        #region [- Actions -]

        #region [- Index() -]

        #region [- Get -]
        public ActionResult Index()
        {
            return View(Ref_CategoryCrud.Select());
        }
        #endregion

        #endregion

        #region [- Details -]

        #region [- Get -]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = Ref_CategoryCrud.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        #endregion

        #endregion

        #region [- Create() -]

        #region [- Get -]
        public ActionResult Create()
        {
            return View();
        }
        #endregion

        #region [- Post -]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryName,Descriptions")] Category category)
        {
            if (ModelState.IsValid)
            {
                Ref_CategoryCrud.Insert(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }
        #endregion

        #endregion

        #region [- Edit() -]

        #region [- Get -]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = Ref_CategoryCrud.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        #endregion

        #region [- Post -]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,CategoryName,Descriptions")] Category category)
        {
            if (ModelState.IsValid)
            {
                Ref_CategoryCrud.Update(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }
        #endregion

        #endregion

        #region [- Delete -]

        #region [- Get -]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = Ref_CategoryCrud.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        #endregion

        #region [- Post -]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ref_CategoryCrud.Delete(id);
            return RedirectToAction("Index");
        }
        #endregion

        #endregion

        #endregion
    }
}