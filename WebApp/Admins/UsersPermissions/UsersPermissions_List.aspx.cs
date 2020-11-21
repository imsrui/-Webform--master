using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace WebApp.Admins.UsersPermissions
{
    public partial class UsersPermissions_List : System.Web.UI.Page
    {
        private readonly RolesService roleSvc = new RolesService();
        private readonly UsersPermissionService permissionSvc = new UsersPermissionService();
        private readonly SystemMenusService menuSvc = new SystemMenusService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            RolesBind();
            Bind();
        }


        public void RolesBind()
        {
            var data = roleSvc.GetAll();
            this.ddlRoles.DataSource = data;
            this.ddlRoles.DataValueField = "Roles_Id";
            this.ddlRoles.DataTextField = "Roles_Title";
            this.ddlRoles.DataBind();
        }


        //这个是当前界面打开时,默认的绑定方式
        public void Bind()
        {
            //1. 得到当前下拉列表的默认值
            var val = Guid.Parse(this.ddlRoles.SelectedValue);
            //2. 通过这个id信息进行查询
            var data = permissionSvc.GetUsersPermissionsesByRolesId(val);
            this.RepHad.DataSource = data; //3. 绑定到对应的Repeater当中
            this.RepHad.DataBind();
            string idList = "";
            foreach (var item in data)
            {
                idList += "'"+item.UsersPermissions_SystemMenuId.ToString()+"',";
            }

            if (data.Count > 0)
            {
                //下面的这个是进行查询,我们未拥有数据
                var menus = menuSvc.GetSystemMenusesByIdList(idList.Substring(0, idList.Length - 1));
                this.RepNoHad.DataSource = menus;
                this.RepNoHad.DataBind();
            }
            else
            {
                var menus = menuSvc.GetAll();
                this.RepNoHad.DataSource = menus;
                this.RepNoHad.DataBind();
            }




        }

        public string GetMenuTitle(Guid menuId)
        {
            var data = menuSvc.GetSystemMenus(menuId);
            return data.SystemMenus_Title;
        }

        //后台未拥有的数据,我们需要通过上面查询的已拥有数据在所有数据当中进行筛选,把不包含的想拿出来

        //这个是删除的点击事件
        protected void Button1_OnClick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.RepHad.Items.Count; i++)
            {
                CheckBox cb = (CheckBox)this.RepHad.Items[i].FindControl("ckId");
                Label lbl = (Label)this.RepHad.Items[i].FindControl("UsersPermissionId");
                if (cb != null)
                {
                    if (cb.Checked)
                    {
                        permissionSvc.Delete(Guid.Parse(lbl.Text));
                    }
                }
            }
            Response.Redirect("UsersPermissions_List.aspx");

        }

        //这个是新增的点击事件
        protected void Button2_OnClick(object sender, EventArgs e)
        {
            //如果我们把正常的服务器控件写在了Repeater控件内部,我们无法直接找到他们
            //我们只能先去找到对应的Repeater控件,之后再控件内部进行查找

            for (int i = 0; i < this.RepNoHad.Items.Count; i++)
            {
               CheckBox cb =  (CheckBox)this.RepNoHad.Items[i].FindControl("ckNoHavId");
               Label lbl = (Label)this.RepNoHad.Items[i].FindControl("MenuId");
               if (cb != null)
               {
                   if (cb.Checked)
                   {
                       permissionSvc.Add(new Model.UsersPermissions()
                       {
                           UsersPermissions_RolesId = Guid.Parse(this.ddlRoles.SelectedValue),
                           UsersPermissions_SystemMenuId = Guid.Parse(lbl.Text)
                       });
                   }
               }
            }

            Response.Redirect("UsersPermissions_List.aspx");


        }

        protected void ddlRoles_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Bind();
        }
    }
}