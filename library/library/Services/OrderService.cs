using library.Entities;
using Microsoft.AspNetCore.Mvc;

namespace library.Services
{
    public class OrderService
    {
        public List<Order> GetOrders() => DataContext.Orders;
        public Order GetOrder(int code) =>
            DataContext.Orders.Find(order => order.Code == code);
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
            if (order == null) return false;
            DataContext.Orders.Add(order);
            return true;
        }
        public bool UpdateOrder(int code, [FromBody] Order order)
        {
            if (order == null) { return false; }
            for (int i = 0; i < DataContext.Orders.Count; i++)
            {
                if (DataContext.Orders[i].Code == code)
                {
                    DataContext.Orders[i].BookName = order.BookName;
                    DataContext.Orders[i].BookCode = order.BookCode;
                    DataContext.Orders[i].PublishName = order.BookName;
                    DataContext.Orders[i].Tel = order.Tel;
                    DataContext.Orders[i].OrderDate = order.OrderDate;
                    DataContext.Orders[i].Copies = order.Copies;
                    DataContext.Orders[i].Price = order.Price;
                    DataContext.Orders[i].ShippingPrice = order.ShippingPrice;
                    return true;
                }
            }
            return false;
        }
        public bool DeleteOrder(int code) =>
             DataContext.Orders.Remove(GetOrder(code));
        //{
        //    for (int i = 0; i < DataContext.Orders.Count; i++)
        //    {
        //        if (DataContext.Orders[i].Code == code)
        //        {
        //            DataContext.Orders.RemoveAt(i);
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
