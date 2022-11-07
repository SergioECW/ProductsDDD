using Microsoft.Extensions.Options;
using Products.Core.Entities;
using Products.Core.Interfaces;
using Products.Core.Exceptions;
using Products.Core.QueryFilter;
using Products.Core.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Products.Core.Exceptions.BusinessExceptions;

namespace Products.Core.Services
{
    public class ProductService : IProductService
    {
        
    
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _unitOfWork.ProductRepository.GetById(id);
        }

        public PagedList<Product> GetProducts(ProductQueryFilter filters)
        {
            var Products = _unitOfWork.ProductRepository.GetAll();

            if (filters.Id != null)
            {
                Products = Products.Where(x => x.Id == filters.Id);
            }

            if (filters.Descripcion != null)
            {
                Products = Products.Where(x => x.Descripcion.ToLower().Contains(filters.Descripcion.ToLower()));
            }

            var pagedProducts = PagedList<Product>.Create(Products, filters.PageNumber, filters.PageSize);
            return pagedProducts;
        }

        public async Task InsertProduct(Product product)
        {
            var user = await _unitOfWork.ProductRepository.GetById(product.Id);
            if (user == null)
            {
                throw new BusinessException("User doesn't exist");
            }

            var userProduct = await _unitOfWork.ProductRepository.GetProducts();
            if (userProduct.Count() < 10)
            {
                var lastProduct = userProduct.First();
            }

            if (product.Descripcion.Contains("Sexo"))
            {
                throw new BusinessException("Content not allowed");
            }

            await _unitOfWork.ProductRepository.Add(product);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var existingProduct = await _unitOfWork.ProductRepository.GetById(product.Id);
            existingProduct.Image = product.Image;
            existingProduct.Descripcion = product.Descripcion;

            _unitOfWork.ProductRepository.Update(existingProduct);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            await _unitOfWork.ProductRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public Task<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProducts(int id)
        {
            throw new NotImplementedException();
        }

        public Task InsertProducts(Product Products)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProducts(Product Products)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProducts(int id)
        {
            throw new NotImplementedException();
        }
    }
}

