using Entities.Models;
using Entities.RequestParameter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Repositories;
using Repositories.Contracts;
using Services.Contracts;
using StoreApp.ModelsStore;

namespace StoreApp.Controllers
{
    public class ProductController:Controller
    {
      private readonly IServiceManager _services;

        public ProductController(IServiceManager services)
        {
            _services = services;
        }

        public IActionResult Index(ProductRequestParameters p)
        {
           
            var products= _services.ProductService.GetAllProductsWithDetails(p);
            var pagination = new Pagination()
            {
                CurrentPage = p.PageNumber,
                ItemsPerPage = p.PageSize,
                TotalItems = _services.ProductService.GetAllProducts(false).Count()
            };
            return View(new ProductListViewModel()
            {
                Products=products,
                Pagination = pagination
            });
            
        }
          public IActionResult Get([FromRoute(Name ="id")]int id)
        {
           // Product product=_context.Products.First(p=>p.ProductId.Equals(id));
            //return View(product); 

            var model=_services.ProductService.GetOneProduct(id,false);

            return View(model);

           

        }
    }
    
}