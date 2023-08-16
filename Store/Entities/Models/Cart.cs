using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Cart
    {
        public List<Cartline> Lines { get; set; }
        public Cart()
        {
            Lines = new List<Cartline>();
        }
        public virtual void AddItem(Product product, int quantity)
        {
            Cartline? line = Lines.Where(p => p.Product.ProductId == product.ProductId).FirstOrDefault();

            if (line is null)
            {
                Lines.Add(new Cartline()
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public virtual void RemoveItem(Product product)=>
            Lines.RemoveAll(p=>p.Product.ProductId == product.ProductId);

        public decimal ComputeTotalValue()=>Lines.Sum(p=>p.Product.Price*p.Quantity);

        public virtual void Clear()=>Lines.Clear();




    }
}
