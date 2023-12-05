using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDA.ApiModels
{
    public class CartItemModel
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string ItemImage { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public int Quantity { get; set; }

    }
}
