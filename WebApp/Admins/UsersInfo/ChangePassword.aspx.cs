using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace WebApp.Admins.UsersInfo
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        private readonly UsersService usersSvc = new UsersService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            ReturnMsg rm = null;
            var ob = Session["LoginOk"] as Model.Users;
            if (ob.Users_Password == MD5Helper.Md5(this.txtOldPassword.Text))
            {
               int res = usersSvc.ChangePwd(ob.Users_Account, MD5Helper.Md5(this.txtNewPassowrd.Text));
              
               if (res > 0)
               {
                   rm = new ReturnMsg()
                   {
                       Code = StatusCode.Ok,
                       Message = "修改成功",
                       Data = null
                   };
                   Session["Msg"] = rm;
                   Response.Redirect("../Welcome/Welcome.aspx");
                }
               else
               {
                   rm = new ReturnMsg()
                   {
                       Code = StatusCode.Error,
                       Message = "修改密码失败",
                       Data = null

                   };
                   Session["Msg"] = rm;
                    Response.Redirect("ChangePassword.aspx");
                }
            }
            else
            {
                 rm = new ReturnMsg()
                {
                    Code = StatusCode.Error,
                    Message = "输入的旧密码不匹配请重新输入",
                    Data = null
                };
                 Session["Msg"] = rm;
                Response.Redirect("ChangePassword.aspx");
            }


        }

        protected void btnReset_OnClick(object sender, EventArgs e)
        {
            this.txtNewPassowrd.Text = this.txtOldPassword.Text = "";
        }
    }
}