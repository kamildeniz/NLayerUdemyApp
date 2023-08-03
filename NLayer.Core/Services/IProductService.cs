using NLayer.Core.DTOs;
using NLayer.Core.Models;

namespace NLayer.Core.Services
{
    public interface IProductService : IService<Product>
    {
        public Task<List<ProductWithCategoryDto>> GetProductsWithCategory();
    }
}
