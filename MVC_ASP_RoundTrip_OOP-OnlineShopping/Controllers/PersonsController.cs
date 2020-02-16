using MVC_ASP_RoundTrip_OOP_OnlineShopping.Models.DomainModels.DTO.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC_ASP_RoundTrip_OOP_OnlineShopping.Controllers
{
    public class PersonsController : Controller
    {
        #region [- ctor -]
        public PersonsController()
        {
            Ref_PersonCrud = new Models.DomainModels.POCO.PersonCrud();
        }
        #endregion

        #region [- props -]
        public Models.DomainModels.POCO.PersonCrud Ref_PersonCrud { get; set; }
        #endregion

        #region [- Actions -]

        #region [- Index() -]

        #region [- Get -]
        public ActionResult Index()
        {
            return View(Ref_PersonCrud.Select());
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
            Person person = Ref_PersonCrud.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
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
        public ActionResult Create([Bind(Include = "Title,NationalCode,FirstName,Surname,Country,DateofBirth,ContactEmail,MobileNumber,Username,Password,Address")] Person person)
        {
            if (ModelState.IsValid)
            {
                Ref_PersonCrud.Insert(person);
                return RedirectToAction("Index");
            }

            return View(person);
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
            var person = Ref_PersonCrud.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }
        #endregion

        #region [- Post -]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,NationalCode,FirstName,Surname,Country,DateofBirth,ContactEmail,MobileNumber,Username,Password,Address")] Person person)
        {
            if (ModelState.IsValid)
            {
                Ref_PersonCrud.Update(person);
                return RedirectToAction("Index");
            }
            return View(person);
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
            var person = Ref_PersonCrud.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }
        #endregion

        #region [- Post -]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ref_PersonCrud.Delete(id);
            return RedirectToAction("Index");
        }
        #endregion

        #endregion

        #endregion
    }
}