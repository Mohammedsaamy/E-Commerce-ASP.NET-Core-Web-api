using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Create
{
    public class CreateOrderDTO
    {

        public int CustomerId { get; set; }
        public string Status { get; set; }

        public List<OrderProductDTO> Products { get; set; }
    }
    public class OrderProductDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

}

