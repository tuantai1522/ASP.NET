using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing.Constraints;
using MyWeb.DataAccess.Repository.IRepository;
using MyWeb.Models;
using MyWeb.Models.ViewModels;

namespace MyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        //Connect database by using ASP.NET Core
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            //includeProperties: Category
            List<Product> products = _unitOfWork.Product.GetAll("Category").ToList();
            

            return View(products);
        }

        //Create new product
        public IActionResult Upsert(int? id)
        {
            //to create list so people can choose from dropdown
            ProductVM productVM = new ProductVM
            {
                CategoryList = _unitOfWork.Category
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.CategoryName,
                    Value = u.CategoryID.ToString()
                }),
                Product = new Product()
            };

            //insert
            if(id == null || id == 0)
            {
                return View(productVM);
            }
            else //update
            {
                productVM.Product = _unitOfWork.Product.GetFirstOrDefault(u => u.ProductID == id, "Category");
            }
            return View(productVM);
        }


        [HttpPost]
        //alow file null when editing
        public IActionResult Upsert(ProductVM obj, IFormFile? file)
        {
            //check valid or not
            if (obj.Product.Price == obj.Product.Price50 ||
                obj.Product.Price50 == obj.Product.Price100 ||
                obj.Product.Price == obj.Product.Price100) // to add my custom error when checking
            {
                ModelState.AddModelError("ModelOnly", "All prices can not be the same");
            }

            if (obj.Product.Price > obj.Product.ListPrice ||
                obj.Product.Price50 > obj.Product.ListPrice ||
                obj.Product.Price100 > obj.Product.ListPrice) // to add my custom error when checking
            {
                ModelState.AddModelError("ModelOnly", "All prices must be smaller than list price");
            }
            if (ModelState.IsValid)
            {
                //working with image url
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if(file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName); // to create random name
                    string productPath = Path.Combine(wwwRootPath, @"images\Product"); // folder to store all images url


                    //if image can find in images folder
                    
                    if (!string.IsNullOrEmpty(obj.Product.ImageUrl))
                    {
                        //Delete the old image

                        //TrimStart: loại bọ kí tự '\' ở đầu
                        var oldImagePath =
                            Path.Combine(wwwRootPath, obj.Product.ImageUrl.TrimStart('\\'));

                        if(System.IO.File.Exists(oldImagePath)) 
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    //final location of storing image url
                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    obj.Product.ImageUrl = @"\images\product\" + fileName; //store in obj to store in database

                }

                //insert
                if (obj.Product.ProductID == 0)
                {
                    //is I don't add image
                    if (string.IsNullOrEmpty(obj.Product.ImageUrl))
                    {
                        obj.Product.ImageUrl = "";
                    }
                    _unitOfWork.Product.Add(obj.Product);
                }
                else //Update
                {
                    _unitOfWork.Product.Update(obj.Product);
                }
                _unitOfWork.Save();
                //add notifications
                TempData["success"] = "Product is saved successfully";
                return RedirectToAction("Index");
            }
            else //if not valid => show CategoryList for the next time
            {
                ProductVM productVM = new ProductVM
                {
                    CategoryList = _unitOfWork.Category
                    .GetAll().Select(u => new SelectListItem
                    {
                        Text = u.CategoryName,
                        Value = u.CategoryID.ToString()
                    }),
                    Product = new Product()
                };
                return View(productVM);

            }
        }

        //Get Product
        public IActionResult Details(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productFromDb = _unitOfWork.Product.GetFirstOrDefault(c => c.ProductID == id, "Category");
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }

        //Delete Product
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productFromDb = _unitOfWork.Product.GetFirstOrDefault(c => c.ProductID == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }

        //name this as DeletePost so this can be move to Delete Views
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product? productFromDb = _unitOfWork.Product.GetFirstOrDefault(c => c.ProductID == id, "Category");
            if (productFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(productFromDb);
            _unitOfWork.Save();
            TempData["success"] = "Product is deleted  successfully";

            return RedirectToAction("Index");

        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            //includeProperties: Category
            List<Product> products = _unitOfWork.Product.GetAll("Category").ToList();

            return Json(new {data = products});
        }
        #endregion
    }
}
