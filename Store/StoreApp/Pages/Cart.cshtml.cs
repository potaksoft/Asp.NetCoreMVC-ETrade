using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using StoreApp.Infrastructure.Extensions;
using System.Security.Cryptography.X509Certificates;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager _services;
        public Cart Cart { get; set; }// IOC
        public string ReturnUrl { get; set; } = "/";
        public CartModel(IServiceManager services,Cart cartService)
        {
            _services = services;
            Cart= cartService;
           
        }

      
      
        public void OnGet(string returnuRL)
        {
            ReturnUrl= returnuRL ?? "/";
           // Cart = HttpContext.Session.GetJson<Cart>("cart")?? new Cart();
        }
       public IActionResult OnPost(int productId,string returnUrl)
        {
            Product? product = _services.ProductService.GetOneProduct(productId, false);
            if (product is not null)
            {
               // Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, 1);
               // HttpContext.Session.SetJson<Cart>("cart", Cart);
            }
            return RedirectToPage(new {returnUrl=returnUrl});//returnUrl
        }
        public IActionResult OnPostRemove(int id,string returnUrl)
        {
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.RemoveItem(Cart.Lines.First(p => p.Product.ProductId == id).Product);
            //HttpContext.Session.SetJson<Cart>("cart", Cart);
            return Page();
        }

    }
}
