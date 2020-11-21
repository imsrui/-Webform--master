using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace WebApp.Admins.Seos
{
    public partial class Seos_Remove : System.Web.UI.Page
    {
        private readonly SeosService seosSvc = new SeosService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            var id = Guid.Parse(Request.Params["action"]);

            var rs = seosSvc.PutTrash(id);

            var rm = rs > 0 ? new ReturnMsg()
            {
                Code = StatusCode.Ok,
                Message = "放入回收站成功",
                Data = null
            } : new ReturnMsg()
            {
                Code = StatusCode.Ok,
                Message = "放入回收站失败",
                Data = null
            };
            Session["Msg"] = rm;
            Response.Redirect("Seos_List.aspx");

        }
    }
}