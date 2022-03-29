using System.Linq;
using TechShop.Data.Entities;

namespace TechShop.Data.Repositories
{
    public interface IStoreRepository {

        IQueryable<Product> Products { get; }
        IQueryable<Product> ProductsToCart { get; }
        public Product Product(int productId);

        IQueryable<TypeProduct> TypeProducts { get; }

        void SaveProduct(Product p);
        void CreateProduct(Product p);
        void DeleteProduct(Product p);
        Product DeleteProduct(int productID);

        void AddImg(long productId, byte[] imageData);

        void SaveTypeProducts(TypeProduct p);
        TypeProduct DeleteTypeProducts(int id);

        void CreateComment(Comment c);
    }
}
