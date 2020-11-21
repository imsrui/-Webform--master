using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
namespace WebApp.Admins.SystemMenu
{
    public partial class SystemMenus_Edit : System.Web.UI.Page
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

            Bind();
        }

        public void Bind()
        {
            Guid id = Request.Params["action"] == null ? Guid.Empty : Guid.Parse(Request.Params["action"]);
            if (id == Guid.Empty)
            {
                Response.Write("<script>alert('数据丢失,请重试');location.href='SystemMenus_List.aspx'</script>");
            }
            var data = menuSvc.GetSystemMenus(id);
            this.HiddenField1.Value = data.SystemMenus_Id.ToString();
            this.txtName.Text = data.SystemMenus_Title;
            this.txtLink.Text = data.SystemMenus_Link;
            this.txtIcon.Text = data.SystemMenus_Icon;
            //parentId 如果为 Guid.Empty 这个就是一级菜单
            //当我们的这个值不是空的,有值的情况 是不是就需要判断 这个到底是几级菜单啊 这个地方怎么判断?

            if (data.SystemMenus_ParentId != Guid.Empty)
            {
                //需要我们判断这个内容到底是二级菜单还是三级菜单

                var parentData = menuSvc.GetSystemMenus(data.SystemMenus_ParentId);
                if (parentData.SystemMenus_ParentId == Guid.Empty)
                {
                    //这个情况是二级菜单
                    this.ddlFirst.SelectedValue = "2";
                    this.ddlSecond.Style.Add("display", "block");
                    var parentdatas = menuSvc.GetSystemMenusByParentId(Guid.Empty);
                    this.ddlSecond.DataSource = parentdatas;
                    this.ddlSecond.DataTextField = "SystemMenus_Title";
                    this.ddlSecond.DataValueField = "SystemMenus_Id";
                    this.ddlSecond.DataBind();

                    this.ddlSecond.SelectedValue = parentData.SystemMenus_Id.ToString();
                }
                else
                {
                    //这个是三级菜单
                    this.ddlFirst.SelectedValue = "3";
                }
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var data = menuSvc.GetSystemMenus(Guid.Parse(this.HiddenField1.Value));
            data.SystemMenus_Title = this.txtName.Text;
            data.SystemMenus_Link = this.txtLink.Text;
            data.SystemMenus_Icon = this.txtIcon.Text;

            if (this.ddlFirst.SelectedValue == "1")
            {
                data.SystemMenus_ParentId = Guid.Empty;
            }
            else if (this.ddlFirst.SelectedValue == "2")
            {
                data.SystemMenus_ParentId = Guid.Parse(this.ddlSecond.SelectedValue);
            }
            else if (this.ddlFirst.SelectedValue == "3")
            {
                data.SystemMenus_ParentId = Guid.Parse(this.ddlThird.SelectedValue);
            }
            data.SystemMenus_UpdateTime = DateTime.Now;
            var res = menuSvc.Edit(data);
            ReturnMsg rm = res > 0
              ? new ReturnMsg()
              {
                  Code = StatusCode.Ok,
                  Message = "编辑系统菜单成功",
                  Data = null
              }
              : new ReturnMsg()
              {
                  Code = StatusCode.Error,
                  Message = "编辑系统菜单失败",
                  Data = null
              };

            Session["Msg"] = rm; //用于传递执行信息的
            Response.Redirect("SystemMenus_List.aspx");
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Bind();
        }

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
                this.ddlThird.DataSource = data;
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