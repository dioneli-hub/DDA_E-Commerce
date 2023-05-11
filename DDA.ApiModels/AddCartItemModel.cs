using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDA.ApiModels
{
    public class AddCartItemModel
    {
        public int ItemId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
    }
}
