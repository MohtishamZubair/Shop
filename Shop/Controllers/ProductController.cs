using System;
using System.Web.Mvc;
using Shop.Services;
using Shop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Controllers
{
    public class ProductController : ShopController
    {
        private IEntityService<Product> service;
        private IEntityService<Category> categoryService;

        public ProductController(IEntityService<Product> service, IEntityService<Category> categoryService)
        {
            this.service = service;
            this.categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var products = service.GetAll(1, 10);
            IEnumerable<ProductView> pv = AutoMapperHelper.Get<IEnumerable<Product>, IEnumerable<ProductView>>(products);
            ProductViewAll pva = new ProductViewAll { ProductViews = pv, TotalCount = pv.Count() };
            return View("Index", pva);
        }

        public ActionResult Create()
        {
            ProductView pv = new ProductView();
            return GetFormView(pv, FormTitle: "Add New Product", FormAction: "Create", FormActionHeading: "Add NewProduct", FormSubmitText: "Save New Product");
        }

        [HttpPost]
        public ActionResult Create(ProductView pv)
        {
            if (ModelState.IsValid)
            {
                Product productToAdd = AutoMapperHelper.Get<ProductView, Product>(pv);

                if (pv.CategoryId.HasValue)
                {
                    var categoryLinked = categoryService.GetById(pv.CategoryId.Value);
                    categoryLinked.Products.Add(productToAdd);
                    categoryService.save(categoryLinked);
                }
                else
                {
                    var newlyProduct = service.Add(productToAdd);
                }

                return RedirectToAction("Index");
            }

            return GetFormView(pv, FormTitle: "Add New Product", FormAction: "Create", FormActionHeading: "Add NewProduct", FormSubmitText: "Save New Product");
        }

        public ActionResult Edit(int id)
        {
            Product product = service.GetById(id);
            StringBuilder selectedCategories = new StringBuilder();

            TempData["AlreadyCategoryIds"] = product.Categories.Select(c => c.CategoryId).ToArray();
            ProductView pv = AutoMapperHelper.Get<Product, ProductView>(product);

            return GetFormView(pv, FormTitle: "Edit Product", FormAction: string.Format("Edit/{0}",id), FormActionHeading: "Edit Product", FormSubmitText: "Save Product");
        }

        [HttpPost]
        public ActionResult Edit(ProductView pv)
        {
            if (ModelState.IsValid)
            {
                Product productToUpdate = AutoMapperHelper.Get<ProductView, Product>(pv);
                var updatedProduct = service.save(productToUpdate);

                if (pv.CategoryId.HasValue && !(TempData["AlreadyCategoryIds"] as int[]).Contains(pv.CategoryId.Value))
                {
                    var categoryLinked = categoryService.GetById(pv.CategoryId.Value);
                    categoryLinked.Products.Add(updatedProduct);
                    categoryService.save(categoryLinked);
                }

                return RedirectToAction("Index");
            }
            return GetFormView(pv, FormTitle: "Edit Product", FormAction: "Edit", FormActionHeading: "Edit Product", FormSubmitText: "Save Product");
        }

        private ActionResult GetFormView(ProductView pv, string FormTitle, string FormAction, string FormActionHeading, string FormSubmitText)
        {
            pv.SetProductForm(FormTitle, FormAction, FormActionHeading, FormSubmitText);
            pv.CategoryList = SetSelectList(pv.CategoryId.ToString());
            return View("InputProduct", pv);
        }

        private void SetEditForm(ProductView pv)
        {

            pv.SetProductForm(FormTitle: "Edit Product", FormAction: "Edit", FormActionHeading: "Edit Product", FormSubmitText: "Save Product");
            pv.CategoryList = SetSelectList(pv.CategoryId.ToString());
        }

        private IEnumerable<SelectListItem> SetSelectList(string CategoryIdSelected)
        {
            IEnumerable<Category> categories = categoryService.GetAll(1, 10);
            return categories.Select(c => new SelectListItem { Text = c.Name, Value = c.CategoryId.ToString(), Selected = c.CategoryId.ToString() == CategoryIdSelected });
        }


    }
}