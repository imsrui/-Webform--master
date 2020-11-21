using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace DAL
{
    public class OrderManager
    {
        public int Add(Order model)
        {
            string sql = "insert into [Order](Order_Id,Order_Name,Order_Phone,Order_Amount,Order_Date,Order_IsRead) values(@Order_Id,@Order_Name,@Order_Phone,@Order_Amount,@Order_Date,@Order_IsRead)";
            return SqlHelper<Order>.ExceuteNonQuery(sql, model);
        }

        public IList<Order> GetAll()
        {
            string sql = "select * from [Order] order by Order_IsRead desc , Order_Date desc";
            return SqlHelper<Order>.Query(sql, null);
        }

        public IList<Order> GetOrder(string name)
        {
            string sql = "select * from [Order] where Order_Name like @Order_Name order by Order_IsRead desc , Order_Date desc";
            return SqlHelper<Order>.Query(sql, new Order() { Order_Name = "%" + name + "%" });
        }

        public int ContactOrder(Guid orderId)
        {
            string sql = "update [Order] set Order_IsRead = 1 where Order_Id = @Order_Id  ";
            return SqlHelper<Order>.ExceuteNonQuery(sql, new Order() { Order_Id = orderId });
        }

        public string GetOrderName(Guid id)
        {
            string sql = "select * from [Order] where Order_Id = @Order_Id ";
            return SqlHelper<Order>.Query(sql, new Order { Order_Id = id }).FirstOrDefault().Order_Name;
        }

    }
}