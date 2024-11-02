using library.Entities;
using Microsoft.AspNetCore.Mvc;

namespace library.Services
{
    public class OrderService
    {
        private List<Order> orders = new List<Order>();    
        public List<Order> GeOrders()
        {
            return orders;
        }
        public Order GetOrder(int code)
        {
            foreach (var order in orders)
            {
                if (order.Code == code)
                    return order;
            }
            return null;
        }
        public bool PostOrder([FromBody] Order order)
        {
            if (order == null)
                return false;
            orders.Add(order);
            return true;
        }
        public bool PutOrder(int code, [FromBody] Order order)
        {
            if (order == null) { return false; }
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].Code == code)
                {
                    orders[i] = order;
                    return true;
                }
            }
            return false;
        }
        public bool DeleteOrder(int code)
        {
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].Code == code)
                {
                    orders.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}
