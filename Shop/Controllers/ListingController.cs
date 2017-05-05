using System;
using System.Web.Mvc;
using Shop.Models;
using Shop.Services;

namespace Shop.Controllers
{
    [Authorize(Roles = "admin,vendor")]
    public class ListingController : ShopController
    {
        private IEntityService<ProductListing> service;

        public ListingController(IEntityService<ProductListing> service)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            var allListings = service.Get(l => l.ShopUserId == UserId);
            return View(allListings);
        }
    }
}