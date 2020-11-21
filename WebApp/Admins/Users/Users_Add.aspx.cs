using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace WebApp.Admins.Users
{
    public partial class Users_Add : System.Web.UI.Page
    {
        private readonly UsersService usersSvc = new UsersService(); 
        private readonly RolesService rolesSvc = new RolesService();
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
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
           Model.Users u = new Model.Users
           {
               Users_Account =  this.txtEmail.Text,
               Users_Password = this.txtPassword.Text,
               Users_NickName = this.txtNickName.Text,
               Users_Photo = upFileName(this.FileUpload1,"../../upload/users/"),
               Users_RolesId = Guid.Parse(this.ddlRolesId.SelectedValue)
           };
           var res = usersSvc.Add(u);
           ReturnMsg rm = res > 0
               ? new ReturnMsg()
               {
                   Code = StatusCode.Ok,
                   Message = "新增用户信息成功",
                   Data = null
               }
               : new ReturnMsg()
               {
                   Code = StatusCode.Error,
                   Message = "新增用户信息失败",
                   Data = null
               };

           Session["Msg"] = rm; //用于传递执行信息的
           Response.Redirect("Users_List.aspx");
        }

        protected void btnReset_OnClick(object sender, EventArgs e)
        {
            this.txtEmail.Text = this.txtNickName.Text = this.txtPassword.Text = "";
            this.ddlRolesId.SelectedIndex = 0;
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