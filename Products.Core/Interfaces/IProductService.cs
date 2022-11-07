using Products.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Products.Core.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetProducts();

        Task<Product> GetProducts(int id);

        Task InsertProducts(Product Products);

        Task<bool> UpdateProducts(Product Products);

        Task<bool> DeleteProducts(int id);
    }
}
