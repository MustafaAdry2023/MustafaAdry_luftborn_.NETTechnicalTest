using Domain.Entities;
using Domain.Repositories;
using Service.Abstractions;
using Services.Abstractions;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        IUnitOfWork _unitOfWork;
        //ICurrentUserService _currentUserService;

        public ProductService(IUnitOfWork unitOfWork/*, ICurrentUserService currentUser*/)
        {
            _unitOfWork = unitOfWork;
            //_currentUserService = currentUser;
        }

        public async Task<bool> AddNewProductAsync(AddProductDTO model)
        {
            try
            {
                var productAddResult = await _unitOfWork.ProductRepository.AddAsync(new Product
                {
                     Name = model.Name,
                     Description = model.Description,
                     Price = model.Price,
                     PublishDate = model.PublishDate, 
                     CreatedBy = "Admin" /*_currentUserService.Name*/
                    
                });
                if (productAddResult == null || await _unitOfWork.SaveChangesAsync() == 0)
                    return false;

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            try
            {

                var product = await _unitOfWork.ProductRepository.GetAsync(id);

                if (product == null)
                    return false;

                  await _unitOfWork.ProductRepository.RemoveAsync(product);

                await _unitOfWork.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        // should use paging by passing page number and page count
        public async Task<List<ProductDTO>> GetAllAsync()
        {
            try
            {


                var res = await _unitOfWork.ProductRepository.GetAllAsync();

                var productList = (from x in res
                                   select new ProductDTO
                                   {
                                       Id = x.ID,
                                       Price = x.Price,
                                       CreatedBy = x.CreatedBy,
                                       Description = x.Description,
                                       Name = x.Name,
                                       PublishDate = x.PublishDate
                                   }).ToList();

                return productList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            try
            {


                var res = await _unitOfWork.ProductRepository.GetAsync(id);

                var product =  new ProductDTO
                                   {
                                       Price = res.Price,
                                       CreatedBy = res.CreatedBy,
                                       Description = res.Description,
                                       Name = res.Name,
                                       PublishDate = res.PublishDate
                                   };

                return product;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> UpdateProductAsync(UpdateProductDTO model)
        {
            try
            {

                var res = await _unitOfWork.ProductRepository.GetAsync(model.Id);

                res.Description = model.Description;
                res.Name = model.Name;
                res.PublishDate = model.PublishDate;   
                res.Price   = model.Price;
                res.UpdatedBy = "Admin" /*_currentUserService.Name*/;
                res.UpdatedDateTime = DateTime.UtcNow;
                
 
                await _unitOfWork.ProductRepository.UpdateAsync(res);
                await _unitOfWork.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
