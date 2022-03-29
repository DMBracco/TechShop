using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TechShop.Data.Entities;
using TechShop.Data.Repositories;
using TechShop.Models;

namespace TechShop.Controllers {

    public class CartController : Controller {
        private IStoreRepository repository;
        private Cart cart;

        public CartController(IStoreRepository repo, Cart cartService) {
            repository = repo;
            cart = cartService;
        }

        public ViewResult Index(string returnUrl) {
            return View(new CartIndexViewModel {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToCart(int productId, string returnUrl) {
            Product product = repository.ProductsToCart
                .FirstOrDefault(p => p.ProductID == productId);
            if (product != null) {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int productId,
                string returnUrl) {
            Product product = repository.ProductsToCart
                .FirstOrDefault(p => p.ProductID == productId);

            if (product != null) {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}