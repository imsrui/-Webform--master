using System;
using System.Collections.Generic;
using DAL;
using Model;

namespace BLL
{
    public class OrderService
    {
        private readonly OrderManager dal = new OrderManager();

        public int Add(Order model)
        {
            return dal.Add(model);
        }

        public IList<Order> GetAll()
        {
            return dal.GetAll();
        }

        public int ContactOrder(Guid orderId)
        {
            return dal.ContactOrder(orderId);
        }

        public IList<Order> GetOrder(string name)
        {
            return dal.GetOrder(name);
        }

        public string GetOrderName(Guid id)
        {
            return dal.GetOrderName(id);
        }

    }
}