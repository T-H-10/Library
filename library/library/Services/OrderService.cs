using library.Entities;
using Microsoft.AspNetCore.Mvc;

namespace library.Services
{
    public class OrderService
    {
        readonly IDataContext _dataContext;
        public OrderService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<Order> GetOrders() => _dataContext.LoadOrders();
        public Order GetOrder(int code)
        {
            List<Order> orders = _dataContext.LoadOrders();
            if (orders == null) return null;
            return orders.Find(order => order.Code == code);
        }
            
        //{
        //    foreach (var order in DataContext.Orders)
        //    {
        //        if (order.Code == code)
        //            return order;
        //    }
        //    return null;
        //}
        public bool AddOrder([FromBody] Order order)
        {
            List<Order> orders = _dataContext.LoadOrders();
            if (order == null) return false;
            orders.Add(order);
            return _dataContext.SaveOrders(orders);
        }
        public bool UpdateOrder(int code, [FromBody] Order order)
        {
            List<Order> orders = _dataContext.LoadOrders();
            if (order == null) { return false; }
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].Code == code)
                {
                    orders[i].BookName = order.BookName;
                    orders[i].BookCode = order.BookCode;
                    orders[i].PublishName = order.BookName;
                    orders[i].Tel = order.Tel;
                    orders[i].OrderDate = order.OrderDate;
                    orders[i].Copies = order.Copies;
                    orders[i].Price = order.Price;
                    orders[i].ShippingPrice = order.ShippingPrice;
                    return _dataContext.SaveOrders(orders);
                }
            }
            return false;
        }
        public bool DeleteOrder(int code)
        {
            List<Order> orders = _dataContext.LoadOrders();
            // DataContext.Orders.Remove(GetOrder(code));
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].Code == code)
                {
                    orders.RemoveAt(i);
                    return _dataContext.SaveOrders(orders);
                }
            }
            return false;
        }
    }
}
