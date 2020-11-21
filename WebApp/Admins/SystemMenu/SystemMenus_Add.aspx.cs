using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
namespace WebApp.Admins.SystemMenu
{
    public partial class SystemMenus_Add : System.Web.UI.Page
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
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var choose = this.ddlFirst.SelectedValue;
            Guid id = Guid.Empty;
            if (choose == "2")
            {
                //当我们第一个下拉列表的值为2时,那么我们的菜单等级为二级菜单,我们需要去选择一个父级菜单,并且得到这个菜单的id
                id = Guid.Parse(this.ddlSecond.SelectedValue);
            }
            else if (choose == "3")
            {
                //当我们第一个下拉列表的值为3时,那么我们的菜单等级为三级菜单,我们需要去选择一个父级菜单,并且得到这个菜单的id
                id = Guid.Parse(this.ddlThird.SelectedValue);
            }

            var model = new SystemMenus
            {
                SystemMenus_Title = this.txtName.Text,
                SystemMenus_Link = this.txtLink.Text,
                SystemMenus_Icon = this.txtIcon.Text,
                SystemMenus_ParentId = id
            };
            var res = menuSvc.Add(model);
            ReturnMsg rm = res > 0
                  ? new ReturnMsg()
                  {
                      Code = StatusCode.Ok,
                      Message = "新增系统菜单成功",
                      Data = null
                  }
                  : new ReturnMsg()
                  {
                      Code = StatusCode.Error,
                      Message = "新增系统菜单失败",
                      Data = null
                  };

            Session["Msg"] = rm; //用于传递执行信息的
            Response.Redirect("SystemMenus_List.aspx");
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 下拉列表改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlFirst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlFirst.SelectedValue == "1")
            {
                this.ddlSecond.Style.Add("display", "none");
                this.ddlThird.Style.Add("display", "none");
            }
            else if (this.ddlFirst.SelectedValue == "2")
            {
                this.ddlSecond.Style.Add("display", "block");
                var data = menuSvc.GetSystemMenusByParentId(Guid.Empty);
                this.ddlSecond.DataSource = data;
                this.ddlSecond.DataTextField = "SystemMenus_Title";
                this.ddlSecond.DataValueField = "SystemMenus_Id";
                this.ddlSecond.DataBind();

            }
            else if (this.ddlFirst.SelectedValue == "3")
            {
                this.ddlSecond.Style.Add("display", "block");
                this.ddlThird.Style.Add("display", "block");
                var data = menuSvc.GetSystemMenusByParentId(Guid.Empty);
                this.ddlSecond.DataSource = data;
                this.ddlSecond.DataTextField = "SystemMenus_Title";
                this.ddlSecond.DataValueField = "SystemMenus_Id";
                this.ddlSecond.DataBind();

                var secondData = menuSvc.GetSystemMenusByParentId(Guid.Parse(this.ddlSecond.SelectedValue));
                this.ddlThird.DataSource = secondData;
                this.ddlThird.DataTextField = "SystemMenus_Title";
                this.ddlThird.DataValueField = "SystemMenus_Id";
                this.ddlThird.DataBind();
            }
        }

        protected void ddlSecond_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var secondData = menuSvc.GetSystemMenusByParentId(Guid.Parse(this.ddlSecond.SelectedValue));
            this.ddlThird.DataSource = secondData;
            this.ddlThird.DataTextField = "SystemMenus_Title";
            this.ddlThird.DataValueField = "SystemMenus_Id";
            this.ddlThird.DataBind();
        }
    }
}