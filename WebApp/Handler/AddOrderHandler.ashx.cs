using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebApp.Handler
{
    /// <summary>
    /// AddOrderHandler 的摘要说明
    /// </summary>
    public class AddOrderHandler : IHttpHandler
    {
        private readonly OrderService orderSvc = new OrderService();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //这个里面就相当于我们的之前学的Servlet当中 doPost 或者 doGet方法
            var name = context.Request.Params["name"];
            var phone = context.Request.Params["tel"];
            var amount = context.Request.Params["money"];

            var model = new Order()
            {
              Order_Name = name,
              Order_Phone = phone,
              Order_Amount = amount
            };
            var res = orderSvc.Add(model);
            StringBuilder sb = new StringBuilder("{");
            sb.Append("\"result\":\""+(res > 0)+"\"");

            sb.Append("}");
            context.Response.Write(sb);

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}