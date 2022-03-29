using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TechShop.Data.Entities;
using TechShop.Data.Repositories;
using TechShop.Models;

namespace TechShop.Controllers
{
    public class CatalogController : Controller
    {
        private IStoreRepository repository;
        public int PageSize = 6;

        public CatalogController(IStoreRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(string typeProduct, int productPage = 1)
            => View(new ProductsListViewModel
            {
                Products = repository.Products
                    .Where(p => typeProduct == null || p.TypeProducts.Name == typeProduct)
                    .OrderBy(p => p.ProductID)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = typeProduct == null ?
                        repository.Products.Count() :
                        repository.Products.Where(e =>
                            e.TypeProducts.Name == typeProduct).Count()
                },
                CurrentTypeProduct = typeProduct
            });

        public ViewResult Details(int id, string returnUrl)
        {
            var product = repository.Product(id);

            var productView = new ProductViewModel
            {
                ProductID = product.ProductID,
                Name = product.Name,
                DetailedDescription = product.DetailedDescription,
                Price = product.Price,
                Image = product.Image,

                ReturnUrl = returnUrl,

                Comments = product.Comments
            };

            return View(productView);
        }

        public IActionResult AddComment(string newCommentText, int productID, string returnUrl)
        {
            var comment = new Comment
            {
                Text = newCommentText,
                DateOfCreat = DateTime.Now,
                ProductID = productID
            };

            repository.CreateComment(comment);

            return RedirectToAction("Details", new { id = productID, returnUrl = returnUrl });
        }
    }
}
