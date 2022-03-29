using Microsoft.EntityFrameworkCore;
using System.Linq;
using TechShop.Data.Entities;

namespace TechShop.Data.Repositories
{
    public class EFStoreRepository : IStoreRepository {
        private StoreDbContext context;

        public EFStoreRepository(StoreDbContext ctx) {
            context = ctx;
        }

        public IQueryable<Product> Products => context.Products
                            .Include(o => o.TypeProducts);

        public IQueryable<Product> ProductsToCart => context.Products;

        public Product Product(int productId)
        {
            var product = context.Products
                .Include(o => o.Comments)
                .FirstOrDefault(p => p.ProductID == productId);
            return product;
        }

        public IQueryable<TypeProduct> TypeProducts => context.TypeProducts;

        public void CreateProduct(Product p) {
            context.Add(p);
            context.SaveChanges();
        }

        public void DeleteProduct(Product p) {
            context.Remove(p);
            context.SaveChanges();
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products
                    .FirstOrDefault(p => p.ProductID == product.ProductID);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.DetailedDescription = product.DetailedDescription;
                    dbEntry.Price = product.Price;
                    dbEntry.TypeProductId = product.TypeProductId;
                }
            }
            context.SaveChanges();
        }

        public Product DeleteProduct(int productID)
        {
            Product dbEntry = context.Products
                .FirstOrDefault(p => p.ProductID == productID);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void AddImg(long productId, byte[] imageData)
        {
            Product dbEntry = context.Products
                .FirstOrDefault(p => p.ProductID == productId);

            dbEntry.Image = imageData;
            context.SaveChanges();
        }

        public void SaveTypeProducts(TypeProduct t)
        {
            if (t.Id == 0)
            {
                context.TypeProducts.Add(t);
            }
            else
            {
                var dbEntry = context.TypeProducts
                    .FirstOrDefault(p => p.Id == t.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = t.Name;
                    dbEntry.Sort = t.Sort;
                }
            }
            context.SaveChanges();
        }

        public TypeProduct DeleteTypeProducts(int id)
        {
            var dbEntry = context.TypeProducts
                .FirstOrDefault(p => p.Id == id);
            if (dbEntry != null)
            {
                context.TypeProducts.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void CreateComment(Comment c)
        {
            context.Add(c);
            context.SaveChanges();
        }
    }
}
