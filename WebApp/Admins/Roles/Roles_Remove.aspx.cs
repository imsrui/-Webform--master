using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace WebApp.Admins.Roles
{
    public partial class Roles_Remove : System.Web.UI.Page
    {
        private readonly  RolesService roleSvc = new RolesService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            object ob = Session["LoginOk"];
            if (ob == null)
            {
                Response.Write("<script>alert('账号过期,请重新登入');location.href='../Login.aspx'</script>");
            }

            var id = Request.Params["action"];
            if (id != null)
            {
                Guid rid = Guid.Parse(id);
                var res = roleSvc.PutTrash(rid);
                ReturnMsg rm = res > 0 ? new ReturnMsg()
                    {
                        Code = StatusCode.Ok,
                        Message = "删除权限成功",
                        Data = null
                    }
                    : new ReturnMsg()
                    {
                        Code = StatusCode.Error,
                        Message = "删除权限失败",
                        Data = null
                    };
                Session["Msg"] = rm;
                Response.Redirect("Roles_List.aspx");
            }
        }
    }
}