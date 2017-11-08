using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobs.Domain
{
    public class PizzaOrderManager
    {
        public static List<DTO.OrderCopy> GetOrders()
        {
            var orders = Persistence.PizzaOrdersRepository.GetOrders();
            return orders;
        }

        public static void AddOrder(DTO.OrderCopy order)
        {
            order.OrderId = Guid.NewGuid();
            Persistence.PizzaOrdersRepository.AddOrder(order);
        }

        public static void UpdateOrderCompletion(Guid orderId)
        {
            Persistence.PizzaOrdersRepository.UpdateOrderCompletion(orderId);
        }
    }
}
