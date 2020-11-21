using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.Admins.SystemMenu
{
    public partial class SystemMenus_Remove : System.Web.UI.Page
    {
        private readonly SystemMenusService menuSvc = new SystemMenusService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            object ob = Session["LoginOk"];
            if (ob == null)
            {
                Response.Write("<script>alert('账号过期,请重新登入');location.href='../Login.aspx'</script>");
            }

            Guid id = Request.Params["action"] == null ? Guid.Empty : Guid.Parse(Request.Params["action"]);
            if (id == Guid.Empty)
            {
                ReturnMsg rm = new ReturnMsg()
                {
                    Code = StatusCode.Error,
                    Message = "数据丢失,请稍后再试",
                    Data = null
                };
                Session["msg"] = rm;
                Response.Redirect("SystemMenus_List.aspx");
            }
            else 
            {
                var res = menuSvc.PutTrash(id);
                ReturnMsg rm = res > 0 ? new ReturnMsg
                {
                    Code = StatusCode.Ok,
                    Message = "放入回收站成功",
                    Data = null
                } : new ReturnMsg
                {
                    Code = StatusCode.Error,
                    Message = "放入回收站失败",
                    Data = null
                };
                Session["msg"] = rm;
                Response.Redirect("SystemMenus_List.aspx");

            }

        }
    }
}