using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.AspNetCore.Http;
using TechShop.Data.Repositories;
using TechShop.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TechShop.Controllers {

    [Authorize]
    public class AdminController : Controller {
        private IStoreRepository repository;

        public AdminController(IStoreRepository repo) {
            repository = repo;
        }

        public ViewResult Index() => View(repository.Products);

        public IActionResult Edit(int productId)
        {
            var product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            ViewBag.TypeProducts = TypeProductsSelectList();

            return View(product);
        }
        
        private SelectList TypeProductsSelectList()
        {
            var typeProductList = repository.TypeProducts.OrderBy(s => s.Sort).ToList();
            return new SelectList(typeProductList, "Id", "Name");
        }

        [HttpPost]
        public IActionResult Edit(Product product) {
            if (ModelState.IsValid) {
                repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction("Index");
            } else {
                ViewBag.TypeProducts = TypeProductsSelectList();
                return View(product);
            }
        }

        public IActionResult Create() {
            ViewBag.TypeProducts = TypeProductsSelectList();
            return View("Edit", new Product());
        }

        [HttpPost]
        public IActionResult Delete(int productId) {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null) {
                TempData["message"] = $"{deletedProduct.Name} was deleted";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddFile(long productId, IFormFile ImageIFormFile)
        {
            var product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            byte[] imageData = null;
            if (product != null)
            {
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(ImageIFormFile.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)ImageIFormFile.Length);
                }
                repository.AddImg(productId, imageData);
                TempData["message"] = $"{product.Name} has been saved";
            }
            

            return RedirectToAction("Index");
        }

        public ViewResult TypeProductsIndex() => View(repository.TypeProducts);

        public IActionResult TypeProductsEdit(int typeProductsId)
        {
            var product = repository.TypeProducts
                .FirstOrDefault(p => p.Id == typeProductsId);

            return View(product);
        }

        [HttpPost]
        public IActionResult TypeProductsEdit(TypeProduct typeProduct)
        {
            if (ModelState.IsValid)
            {
                repository.SaveTypeProducts(typeProduct);
                TempData["message"] = $"{typeProduct.Name} has been saved";
                return RedirectToAction("TypeProductsIndex");
            }
            else
            {
                return View(typeProduct);
            }
        }

        public ViewResult TypeProductsCreate() => View("TypeProductsEdit", new TypeProduct());

        [HttpPost]
        public IActionResult TypeProductsDelete(int typeProductsId)
        {
            var deletedProduct = repository.DeleteTypeProducts(typeProductsId);
            if (deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} was deleted";
            }
            return RedirectToAction("TypeProductsIndex");
        }
    }
}
