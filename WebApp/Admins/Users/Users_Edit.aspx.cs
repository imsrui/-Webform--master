using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace WebApp.Admins.Users
{
    public partial class Users_Edit : System.Web.UI.Page
    {
        private readonly UsersService usersSvc = new UsersService();
        private readonly RolesService rolesSvc = new RolesService();
        public string imgUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            object ob = Session["LoginOk"];
            if (ob == null)
            {
                Response.Write("<script>alert('账号过期,请重新登入');location.href='../Login.aspx'</script>");
            }

            #region 绑定下拉列表

            var data = rolesSvc.GetAll();
            this.ddlRolesId.DataSource = data;
            this.ddlRolesId.DataTextField = "Roles_Title";
            this.ddlRolesId.DataValueField = "Roles_Id";
            this.ddlRolesId.DataBind();



            #endregion


            Bind();

        }


        public void Bind()
        {
            var id = Request.Params["action"] == null ? Guid.NewGuid() : Guid.Parse(Request.Params["action"]);
            var data = usersSvc.GetUsersById(id);
            if (data == null)
            {
                ReturnMsg rm = new ReturnMsg()
                {
                    Code = StatusCode.Error,
                    Message = "数据丢失,请稍后再试",
                    Data = null
                };
                Session["msg"] = rm;
                Response.Redirect("Users_List.aspx");
            }

            this.hfId.Value = data.Users_Id.ToString();
            this.txtEmail.Text = data.Users_Account;
            this.txtPassword.Text = data.Users_Password;
            this.txtNickName.Text = data.Users_NickName;
            imgUrl = data.Users_Photo;
            this.ddlRolesId.SelectedValue = data.Users_RolesId.ToString();
        }


        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            string photo = upFileName(this.FileUpload1, "../../upload/users/");
            Model.Users u = usersSvc.GetUsersById(Guid.Parse(this.hfId.Value));
            if (photo == "")
            {
                u = new Model.Users
                {
                    Users_Account = this.txtEmail.Text,
                    Users_Password = this.txtPassword.Text,
                    Users_NickName = this.txtNickName.Text,
                    Users_RolesId = Guid.Parse(this.ddlRolesId.SelectedValue),
                    Users_UpdateTime = DateTime.Now
                };
            }
            else
            {
                u = new Model.Users
                {
                    Users_Account = this.txtEmail.Text,
                    Users_Password = this.txtPassword.Text,
                    Users_NickName = this.txtNickName.Text,
                    Users_Photo = photo,
                    Users_RolesId = Guid.Parse(this.ddlRolesId.SelectedValue),
                    Users_UpdateTime = DateTime.Now
                };
            }

            var res = usersSvc.Edit(u);
            ReturnMsg rm = res > 0
                ? new ReturnMsg()
                {
                    Code = StatusCode.Ok,
                    Message = "编辑用户信息成功",
                    Data = null
                }
                : new ReturnMsg()
                {
                    Code = StatusCode.Error,
                    Message = "编辑用户信息失败",
                    Data = null
                };

            Session["Msg"] = rm; //用于传递执行信息的
            Response.Redirect("Users_List.aspx");
        }

        protected void btnReset_OnClick(object sender, EventArgs e)
        {
            Bind();
        }

        #region 上传图像
        public string upFileName(FileUpload f, string url)
        {
            string res = "";
            Random ran = new Random();
            string filePath = f.FileName;
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Convert.ToString(ran.Next(1, 1 + 9999));
            if (filePath != "")
            {
                string fileType = filePath.Substring(filePath.LastIndexOf(".") + 1);
                //string filePic = Server.MapPath(url + filePath);
                string filePic = Server.MapPath(url + fileName + "." + fileType);
                f.PostedFile.SaveAs(filePic);
                res = fileName + "." + fileType;
            }
            return res;
        }
        #endregion
    }
}