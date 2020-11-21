using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace WebApp.Admins.News
{
    public partial class News_Remove : System.Web.UI.Page
    {
        private readonly  NewsService newsSvc = new NewsService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;


            var id = Request.Params["action"] == null ? Guid.Empty : Guid.Parse(Request.Params["action"]);
            var rs = newsSvc.PutTrash(id);
            var rm = rs > 0 ? new ReturnMsg()
            {
                Code = StatusCode.Ok,
                Message = "放入回收站成功",
                Data = null
            } : new ReturnMsg()
            {
                Code = StatusCode.Error,
                Message = "放入回收站失败",
                Data = null
            };
            Session["Msg"] = rm;
            Response.Redirect("News_List.aspx");

        }
    }
}