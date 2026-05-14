using System.Data;
using inventory.DAL;
using inventory.Models;

namespace inventory.BLL
{
    public class ProductService
    {
        private ProductRepository _productRepository = new ProductRepository();

        public DataTable GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public bool SaveProduct(Product product)
        {
            if (product.Id > 0)
                return _productRepository.UpdateProduct(product);
            else
                return _productRepository.AddProduct(product);
        }

        public bool DeleteProduct(int id)
        {
            return _productRepository.DeleteProduct(id);
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public bool UpdateProduct(Product product)
        {
            return _productRepository.UpdateProduct(product);
        }
        public bool PurgeAll()
        {
            return _productRepository.PurgeAllProducts();
        }
    }
}
