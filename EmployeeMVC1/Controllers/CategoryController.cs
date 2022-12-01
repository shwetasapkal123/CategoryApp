using EmployeeMVC1.Data;
using EmployeeMVC1.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMVC1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList=_db.categories;
            return View(objCategoryList);
        }
        //GET Method
        public IActionResult Create()
        {
            return View();
        }
        //Post Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            //Adding custom error msg for Name
            if(obj.Name==obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Display order cannot exactly match name");
            }
            //giving all null values shows exception so added if block
            if (ModelState.IsValid)
            {
                //Adding data to database
                _db.categories.Add(obj);
                //Saving data to database
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                //navigating to index page
                return RedirectToAction("Index");
            }
            //Displaying list
            return View(obj);
        }

        //GET Method
        public IActionResult Edit(int? Id)
        {
            if(Id==null || Id==0)
            {
                return NotFound();
            }
            var categotyFromDb=_db.categories.Find(Id);
            if(categotyFromDb==null)
            {
                return NotFound();
            }
            return View(categotyFromDb);
        }
        //Post Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            //Adding custom error msg for Name
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Display order cannot exactly match name");
            }
            //giving all null values shows exception so added if block
            if (ModelState.IsValid)
            {
                //Updating data to database
                _db.categories.Update(obj);
                //Saving data to database
                _db.SaveChanges();
                TempData["success"] = "Category edited successfully";
                //navigating to index page
                return RedirectToAction("Index");
            }
            //Displaying list
            return View(obj);
        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var categotyFromDb = _db.categories.Find(Id);
            if (categotyFromDb == null)
            {
                return NotFound();
            }
            return View(categotyFromDb);
        }
        //Post Method
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj=_db.categories.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
                //Removing data to database
                _db.categories.Remove(obj);
                //Saving data to database
                _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            //navigating to index page
            return RedirectToAction("Index");
        }
    }
}
