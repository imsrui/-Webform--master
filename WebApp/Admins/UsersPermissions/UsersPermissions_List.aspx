<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/shared/_Backend.Master" AutoEventWireup="true" CodeBehind="UsersPermissions_List.aspx.cs" Inherits="WebApp.Admins.UsersPermissions.UsersPermissions_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>权限分配</title>
    <style>
        .roleddl {
            width: 300px;
            height: 50px;
            line-height: 50px;
            font-size: 18px;
            outline: none;
            padding-left: 100px;
            border: 1px solid #c0c0c0;
            border-radius: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="row mb-1">
        <div class="col-md-10 col-md-offset-1">
            <asp:DropDownList ID="ddlRoles" runat="server" class="roleddl" AutoPostBack="True" OnSelectedIndexChanged="ddlRoles_OnSelectedIndexChanged"></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-md-5 col-md-offset-1">
            <div class="panel">
                <div class="panel-heading">
                    <h3 class="panel-title">已拥有权限</h3>
                </div>
                <div class="panel-body">
                    <table class="table table-bordered table-hover">
                        <tr>
                            <td>
                                <asp:CheckBox ID="ckAll" runat="server" />全选
                            </td>
                            <td>
                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-danger" Text="删除已选中的内容" OnClick="Button1_OnClick" />
                            </td>
                        </tr>
                        <asp:Repeater ID="RepHad" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="ckId"  runat="server" />
                                        <asp:Label runat="server" ID="UsersPermissionId" Text='<%#Eval("UsersPermissions_Id") %>' Visible="False"></asp:Label>
                                    </td>
                                    <td>
                                        <%#GetMenuTitle(Guid.Parse(Eval("UsersPermissions_SystemMenuId").ToString())) %>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>

                    </table>
                    

                </div>

            </div>
            

        </div>
        <div class="col-md-5 col-md-offset-1">
            <div class="panel">
                <div class="panel-heading">
                    <h3 class="panel-title">未拥有权限</h3>
                </div>
                <div class="panel-body">
                    <table class="table table-bordered table-hover">
                        <tr>
                            <td>
                                <asp:CheckBox ID="CheckBox1" runat="server" />全选
                            </td>
                            <td> <asp:Button ID="Button2" runat="server" Text="新增已选中的内容" CssClass="btn btn-success" OnClick="Button2_OnClick" /></td>
                        </tr>
                        <asp:Repeater ID="RepNoHad" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="ckNoHavId"  runat="server" />
                                        <asp:Label runat="server" ID="MenuId" Text='<%#Eval("SystemMenus_Id") %>' Visible="False"></asp:Label>
                                    </td>
                                    <td>
                                        <%#Eval("SystemMenus_Title") %>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>

                    </table>
                    

                </div>

            </div>
            

        </div>

    </div>



</asp:Content>
