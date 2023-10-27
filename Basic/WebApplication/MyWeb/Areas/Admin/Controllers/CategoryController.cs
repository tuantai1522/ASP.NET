using Microsoft.AspNetCore.Mvc;
using MyWeb.DataAccess.Repository.IRepository;
using MyWeb.DataAccess;
using MyWeb.Models;

namespace MyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        //Connect database by using ASP.NET Core
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Category> categories = _unitOfWork.Category.GetAll().ToList();
            return View(categories);
        }

        //Create new Category
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            //check valid or not
            if (obj.CategoryName == obj.DisplayOrder.ToString()) // to add my custom error when checking
            {
                ModelState.AddModelError("ModelOnly", "Name and Display order can not be the same");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                //add notifications
                TempData["success"] = "Category is created successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        //Get Category
        public IActionResult Details(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _unitOfWork.Category.GetFirstOrDefault(c => c.CategoryID == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //Edit Category
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _unitOfWork.Category.GetFirstOrDefault(c => c.CategoryID == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            //check valid or not
            if (obj.CategoryName == obj.DisplayOrder.ToString()) // to add my custom error when checking
            {
                ModelState.AddModelError("ModelOnly", "Name and Display order can not be the same");
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category is updated successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        //Delete Category
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _unitOfWork.Category.GetFirstOrDefault(c => c.CategoryID == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }


        //name this as DeletePost so this can be move to Delete Views
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? categoryFromDb = _unitOfWork.Category.GetFirstOrDefault(c => c.CategoryID == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(categoryFromDb);
            _unitOfWork.Save();
            TempData["success"] = "Category is deleted  successfully";

            return RedirectToAction("Index");

        }

    }
}
