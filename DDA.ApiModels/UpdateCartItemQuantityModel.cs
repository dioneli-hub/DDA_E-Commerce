using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDA.ApiModels
{
    public class UpdateCartItemQuantityModel
    {
        public int CartItemId { get; set; }
        public int Quantity { get; set; }
    }
}
