using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TechShop.Data.Repositories;

namespace TechShop.Components {

    public class NavigationMenuViewComponent : ViewComponent {
        private IStoreRepository repository;

        public NavigationMenuViewComponent(IStoreRepository repo) {
            repository = repo;
        }

        public IViewComponentResult Invoke(string selected) {
            ViewBag.SelectedCategory = selected;
            return View(repository.Products
                .Select(x => x.TypeProducts.Name)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
