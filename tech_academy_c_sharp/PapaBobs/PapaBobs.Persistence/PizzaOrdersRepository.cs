using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobs.Persistence
{
    public class PizzaOrdersRepository
    {
        public static List<DTO.OrderCopy> GetOrders()
        {
            PapaBobsEntities db = new PapaBobsEntities();
            var dbOrders = db.Orders.ToList();

            var dtoOrders = new List<DTO.OrderCopy>();

            foreach (var dbOrder in dbOrders)
            {
                var dtoOrder = new DTO.OrderCopy()
                {
                    OrderId = dbOrder.OrderId,
                    Crust = dbOrder.Crust,
                    Size = dbOrder.Size,
                    PaymentType = dbOrder.PaymentType,
                    Onions = dbOrder.Onions,
                    Green_Peppers = dbOrder.Green_Peppers,
                    Pepperoni = dbOrder.Pepperoni,
                    Sausage = dbOrder.Sausage,
                    TotalCost = dbOrder.TotalCost,
                    Name = dbOrder.Name,
                    Address = dbOrder.Address,
                    Notes = dbOrder.Notes,
                    Phone = dbOrder.Phone,
                    Zip = dbOrder.Zip,
                    Completed = dbOrder.Completed
                };
                dtoOrders.Add(dtoOrder);
            }

            return dtoOrders;
        }

        public static void AddOrder(DTO.OrderCopy newOrder)
        {
            if (!validNewOrder(newOrder))
                throw new Exception("Invalid order for database insertion.");

            Order dbOrder = new Order()
            {
                OrderId = newOrder.OrderId,
                Crust = newOrder.Crust,
                Size = newOrder.Size,
                PaymentType = newOrder.PaymentType,
                Onions = newOrder.Onions,
                Green_Peppers = newOrder.Green_Peppers,
                Pepperoni = newOrder.Pepperoni,
                Sausage = newOrder.Sausage,
                TotalCost = newOrder.TotalCost,
                Name = newOrder.Name,
                Address = newOrder.Address,
                Notes = newOrder.Notes,
                Phone = newOrder.Phone,
                Zip = newOrder.Zip,
                Completed = newOrder.Completed
            };

            using (var db = new PapaBobsEntities())
            {
                try
                {
                    db.Orders.Add(dbOrder);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    // Log the exception.
                    throw ex;
                }
            }
   


        }

        public static void UpdateOrderCompletion(Guid orderId)
        {
            try
            {
                PapaBobsEntities db = new PapaBobsEntities();
                var dbOrder = db.Orders.SingleOrDefault(o => o.OrderId == orderId);
                if (dbOrder != null)
                {
                    dbOrder.Completed = true;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private static bool validNewOrder(DTO.OrderCopy newOrder)
        {
            if (emptyString(newOrder.Name))
                return false;
            if (emptyString(newOrder.Address))
                return false;
            if (emptyString(newOrder.Phone))
                return false;
            if (newOrder.Zip <= 0)
                return false;

            return true;
        }

        private static bool emptyString( string Value ) { return (Value.Trim().Length == 0); }

    }
}
