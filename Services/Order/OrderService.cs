using AutoMapper;
using DTOs.Create;
using DTOs.Display;
using DTOs.Update;
using Models.Model;
using Repository.Contract;
using Repository.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public OrderService(IOrderRepository _orderRepository, IMapper _mapper)
        {
            orderRepository = _orderRepository;
            mapper = _mapper;
        }

        public List<GetAllOrder> GetAll()
        {
            var orders = orderRepository.GetAll().ToList();
            var mappedOrders = mapper.Map<List<GetAllOrder>>(orders);
            return mappedOrders;
        }

        public GetAllOrder GetOne(int OrderId)
        {
            var order = orderRepository.GetOne(OrderId);
            var mappedOrder = mapper.Map<GetAllOrder>(order);
            return mappedOrder;
        }

        public ReturnOrder Create(CreateOrderDTO order)
        {
            var orderEntity = mapper.Map<Models.Model.Order>(order);
            orderRepository.Create(orderEntity);

            // Get the newly created order's ID
            int orderId = orderEntity.OrderId;

            // Create a new ReturnOrder object with the order ID and default status
            var createdOrderDTO = new ReturnOrder
            {
                OrderId = orderId,
                Status = "Sucessed"
            };

            return createdOrderDTO;
        }


        public List<GetAllOrder> Delete(int OrderId)
        {
            var orderDeleted = orderRepository.GetOne(OrderId);
            orderRepository.Delete(orderDeleted);
            var orderDeletedDTO = mapper.Map<List<GetAllOrder>>(orderDeleted);
            return orderDeletedDTO;
        }

        //public UpdateOrderDTO Update(UpdateOrderDTO order, int OrderId)
        //{
        //    var orderUpdated = orderRepository.GetOne(OrderId);
        //    orderRepository.Update(orderUpdated, OrderId);
        //    var orderUpdatedDTO = mapper.Map<UpdateOrderDTO>(orderUpdated);
        //    return orderUpdatedDTO;
        //}
        //public UpdateOrderDTO Update(UpdateOrderDTO order, int orderId)
        //{
        //    var orderEntity = mapper.Map<Models.Model.Order>(order);
        //    orderRepository.Update(orderEntity, orderId); // Provide the 'id' argument here
        //    var updatedOrderDTO = mapper.Map<UpdateOrderDTO>(orderEntity);
        //    return updatedOrderDTO;
        //}
        public ReturnOrder Update(UpdateOrderDTO order, int orderId)
        {
            // Retrieve the order entity from the repository
            var existingOrder = orderRepository.GetOne(orderId);

            // Check if the order exists
            if (existingOrder == null)
            {
                // Return an error DTO indicating that the order does not exist
                return new ReturnOrder
                {
                    OrderId = orderId,
                    Status = "Order not found"
                };
            }

            // Update the order status
            existingOrder.Status = order.Status;

            
           
                // Save changes to the database
                orderRepository.Update(existingOrder, orderId);

                // Return a DTO indicating the success of the update
                return new ReturnOrder
                {
                    OrderId = orderId,
                    Status = "Updated"
                };
            
           
        }



    }
}
