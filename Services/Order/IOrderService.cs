using DTOs.Create;
using DTOs.Display;
using DTOs.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Order
{
    public interface IOrderService
    {

 

        List<GetAllOrder> GetAll();
        GetAllOrder GetOne (int id);
        ReturnOrder Create(CreateOrderDTO CreateOrderDTO);
        List<GetAllOrder> Delete(int id);
        //UpdateOrderDTO Update(UpdateOrderDTO order);
        ReturnOrder Update(UpdateOrderDTO order, int orderId);

    }
}
