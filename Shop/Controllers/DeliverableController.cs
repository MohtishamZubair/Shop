using Shop.Models;
using Shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    [Authorize(Roles ="admin")]
    public class DeliverableController : ShopController
    {
        private IEntityService<Deliverable> service;

        public DeliverableController(IEntityService<Deliverable> service)
        {
            this.service = service;
        }
        // GET: Deliverable
        public ActionResult Index()
        {
            //var deliverable = Enumerable.Range(0, 10)
            //    .Select(x =>
            //    new Deliverable
            //    {
            //        InvoiceId = x,
            //        AddressId = x,
            //        ShopUserId = ;
            //    }
            //    ).ToList();

            var all = service.GetAll().ToList();
            var alldv =  AutoMapperHelper.Get<List<Deliverable>, List<DeliverableView>>(all);
            return View(alldv);
        }

        // GET: Deliverable/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Deliverable/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deliverable/Create
        [HttpPost]
        public ActionResult Create(Deliverable deliverable)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Deliverable/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Deliverable/Edit/5
        [HttpPost]
        public ActionResult Edit(Deliverable deliverable)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Deliverable/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Deliverable/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
