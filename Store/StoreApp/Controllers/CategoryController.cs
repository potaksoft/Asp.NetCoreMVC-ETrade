using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Services.Contracts;

namespace StoreApp.Controllers
{
    public class CategoryController : Controller//Değişmesi lazım cünkü çalışmıyor 
    {
        private readonly IServiceManager _services;

        public CategoryController(IServiceManager services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            var model = _services.CategoryService.GetAllCategories;
            return View(model);

        }
    }
}
