using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace WebApp.Admins.LoanType
{
    public partial class LoanType_Remove : System.Web.UI.Page
    {
        private readonly LoanTypeService typeSvc = new LoanTypeService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            ReturnMsg rm = null;
            var id = Request.Params["action"] == null ? Guid.Empty : Guid.Parse(Request.Params["action"]);

            if (id == Guid.Empty)
            {
                rm = new ReturnMsg()
                {
                    Code = StatusCode.NotFound,
                    Message = "数据丢失,请稍后再试",
                    Data = null
                };
            }
            else
            {
                var rs = typeSvc.Delete(id);
                rm = rs > 0 ? new ReturnMsg()
                {
                    Code = StatusCode.Ok,
                    Message = "删除类型成功",
                    Data = null
                } : new ReturnMsg()
                {
                    Code = StatusCode.Error,
                    Message = "删除类型失败",
                    Data = null
                };
            }

            Session["Msg"] = rm;
            Response.Redirect("LoanType_List.aspx");

        }
    }
}