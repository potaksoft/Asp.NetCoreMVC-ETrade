using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameter;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ProductManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public void CreateProduct(ProductDtoForInsertion productDto)
        {
           Product product=_mapper.Map<Product>(productDto);
           _repositoryManager.Product.Create(product);
            _repositoryManager.Save();
        }

        public void DeleteOneProduct(int id)
        {
            var product = GetOneProduct(id, false);
            if (product is not null)
            {
                _repositoryManager.Product.DeleteOneProduct(product);//bu satırdaki kodun yazılmasının sebebi bu metdodun repositoryde implement edilmek istenemsidir.
                _repositoryManager.Save(); 
            }
           
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
           return _repositoryManager.Product.GetAllProducts(trackChanges);
        }

        public IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters p)
        {
           return _repositoryManager.Product.GetAllProductsWithDetails(p);
        }

        public IEnumerable<Product> GetLastestProducts(int n, bool trackChanges)
        {
            return _repositoryManager
                 .Product
                 .FindAll(trackChanges)
                 .OrderByDescending(prd => prd.ProductId)
                 .Take(n);
        }

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            var product=_repositoryManager.Product.GetOneProduct(id, trackChanges);
            if (product is null)
            {
                throw new Exception("Product Not Found");

            }
            return product;
        }

        public ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges)
        {
           var product=GetOneProduct(id, trackChanges); 
            var productDto=_mapper.Map<ProductDtoForUpdate>(product);
            return productDto;
        }

        public IEnumerable<Product> GetShowCaseProducts(bool trackChanges)
        {
           var products=_repositoryManager.Product.GetShowCaseProducts(trackChanges);
            return products;
        }

        public void UpdateOneProduct(ProductDtoForUpdate productDto)
        {
            //var entity = _repositoryManager.Product.GetOneProduct(productDto.ProductId, true);
            //entity.ProductName = productDto.ProductName;
            //entity.Price = productDto.Price;
            //entity.CategoryId = productDto.CategoryId;

            var entity=_mapper.Map<Product>(productDto);
            _repositoryManager.Product.UpdateOneProduct(entity);

            _repositoryManager.Save();
            
        }

        //object IProductService.GetOneProductForUpdate(int id, bool trackChanges)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
