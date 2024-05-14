using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IProductService
    {
        Task<bool> AddNewProductAsync(AddProductDTO model);
        Task<bool> DeleteProductAsync(int id);
        Task<bool> UpdateProductAsync(UpdateProductDTO model);
        Task<ProductDTO> GetProductByIdAsync(int id);
        Task<List<ProductDTO>> GetAllAsync();

    }
}
