
using Shop.Models;
using Shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class CategoryController : ShopController
    {
        private ICategoryService categoryService = null;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        // GET: Category
        public ActionResult Index(int p=1,int s=10)
        {
            return IndexView(p, s);
        }

        private ActionResult IndexView(int p=1, int s=10,int highLightRowId = -1)
        {
            List<Category> pagedCategories = categoryService.GetAll(p, s);
            List<CategoryView> categoryViews = AutoMapperHelper.Get<List<Category>, List<CategoryView>>(pagedCategories);
            CategoryViewAll data = new CategoryViewAll { CategoryViews = categoryViews, TotalCount = categoryViews.Count, HighLightId = highLightRowId };

            return View("Index", data);
        }        

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            CategoryView cv = GetSingleCategory(id);
            return View(cv);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            PrepareSelectForSubCategoryinView();
            CategoryView categoryView = new CategoryView();
            return View(categoryView);
        }

        private void PrepareSelectForSubCategoryinView(string selectedValue = "")
        {
            List<Category> pagedCategories = categoryService.GetAll();
            List<CategoryView> categoryViews = AutoMapperHelper.Get<List<Category>, List<CategoryView>>(pagedCategories);
           // var selectList = new SelectList(categoryViews,"Id","Name", 8);
            IEnumerable<SelectListItem> categories = categoryViews.Select(
                cv => new SelectListItem{
                    Selected = cv.Id.ToString() == selectedValue,
                    Text = cv.Name,
                    Value = cv.Id.ToString()
                } );
        ViewBag.SubCategoryId = categories.ToList();
            //ViewData.SubCategoryId = selectList;
        }

        //List<Category> categoryViews = Enumerable.Range(0, 5)
        //                           .Select(x => new Category()
        //                           {
        //                               Name = string.Format("categoryname{0}", x),
        //                               CategoryId = x,

        //                           }).ToList();
        //CategoryView categoryView = new CategoryView();
        //categoryView.SubCategoryId = new SelectList(categoryViews, "CategoryId", "Name");


        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(CategoryView categoryView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Category category = AutoMapperHelper.Get<CategoryView, Category>(categoryView);
                    int categoryId = categoryService.Add(category);
                    return IndexView(highLightRowId : categoryId);
                }
            }
            catch(Exception e)
            {
                ModelState.AddModelError("Name", e.Message);
             
               
            }
            PrepareSelectForSubCategoryinView();
            return View(categoryView);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            CategoryView cv = GetSingleCategory(id);
            return View(cv);
        }

        private CategoryView GetSingleCategory(int id)
        {
         
            Category category = categoryService.GetCategoryById(id);
            CategoryView cv = AutoMapperHelper.Get<Category, CategoryView>(category);
            PrepareSelectForSubCategoryinView(category.SubCategoryId.ToString());
            return cv;
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(CategoryView categoryView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Category category = AutoMapperHelper.Get<CategoryView, Category>(categoryView);
                    var result = categoryService.Save(category);
                    return IndexView(highLightRowId: result.CategoryId);
                    //ResultModel result = categoryService.Save(category);
                    //if (result.ResultState)
                    //{}
                }
                else
                {
                    ModelState.ToList().ForEach(ms => {
                        if (ms.Value.Errors.Count > 0)
                        {
                            ModelState.Add(ms);
                        }
                    });
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Name", ex.Message);                
            }
            PrepareSelectForSubCategoryinView();
            return View(categoryView);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Category/Delete/5
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
