using MVC_ASP_RoundTrip_OOP_OnlineShopping.Models.DomainModels.DTO.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC_ASP_RoundTrip_OOP_OnlineShopping.Controllers
{
    public class ProductsController : Controller
    {
        #region [- ctor -]
        public ProductsController()
        {
            Ref_ProductCrud = new Models.DomainModels.POCO.ProductCrud();
            Ref_CategoryCrud = new Models.DomainModels.POCO.CategoryCrud();
        }
        #endregion

        #region [- props -]
        public Models.DomainModels.POCO.ProductCrud Ref_ProductCrud { get; set; }
        public Models.DomainModels.POCO.CategoryCrud Ref_CategoryCrud { get; set; }

        #endregion

        #region [- Actions -]

        #region [- Index() -]

        #region [- Get -]
        public ActionResult Index()
        {
            return View(Ref_ProductCrud.Select());
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
            Product product = Ref_ProductCrud.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        #endregion

        #endregion

        #region [- Create() -]

        #region [- Get -]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(Ref_CategoryCrud.Select(), "CategoryID", "CategoryName");
            return View();
        }
        #endregion

        #region [- Post -]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductCode,ProductName,CategoryId,Quantity,UnitPrice,Discount,Picture,Descriptions")] Product product)
        {
            if (ModelState.IsValid)
            {
                Ref_ProductCrud.Insert(product);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(Ref_CategoryCrud.Select(), product.CategoryId);
            return View(product);
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
            var product = Ref_ProductCrud.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(Ref_CategoryCrud.Select(), "CategoryID", "CategoryName", product.CategoryId);
            return View(product);
        }
        #endregion

        #region [- Post -]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductCode,ProductName,CategoryId,Quantity,UnitPrice,Discount,Picture,Descriptions")] Product product)
        {
            if (ModelState.IsValid)
            {
                Ref_ProductCrud.Update(product);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(Ref_CategoryCrud.Select(), "CategoryID", "CategoryName", product.CategoryId);
            return View(product);
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
            var product = Ref_ProductCrud.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        #endregion

        #region [- Post -]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ref_ProductCrud.Delete(id);
            return RedirectToAction("Index");
        }
        #endregion

        #endregion

        #endregion
    }
}