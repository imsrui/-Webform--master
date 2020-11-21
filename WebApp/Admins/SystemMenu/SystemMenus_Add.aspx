<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/shared/_Backend.Master" AutoEventWireup="true" CodeBehind="SystemMenus_Add.aspx.cs" Inherits="WebApp.Admins.SystemMenu.SystemMenus_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>新增系统菜单</title>
    <style>
        .info {
            text-align:center;
            padding:20px 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row">
        <div class="col-md-offset-1 col-md-10">
            <div class="panel">
                <div class="panel-heading">
                    <h3 class="panel-title">新增系统菜单</h3>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label>系统菜单名称:</label>
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>系统菜单链接:</label>
                        <asp:TextBox ID="txtLink" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>系统菜单图标</label>
                        <div class="row">
                            <div class="col-md-3 info">
                                <span class="lnr lnr-home"></span>
                            </div>
                            <div class="col-md-3 info">
                                <span class="lnr lnr-pencil"></span>
                            </div>
                            <div class="col-md-3 info">
                                <span class="lnr lnr-drop"></span>
                            </div>
                            <div class="col-md-3 info">
                                <span class="lnr lnr-cloud"></span>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3 info">
                                <span class="lnr lnr-cog"></span>
                            </div>
                            <div class="col-md-3 info">
                                <span class="lnr lnr-heart"></span>
                            </div>
                            <div class="col-md-3 info">
                                <span class="lnr lnr-location"></span>
                            </div>
                            <div class="col-md-3 info">
                                <span class="lnr lnr-bookmark"></span>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3 info">
                                <span class="lnr lnr-list"></span>
                            </div>
                            <div class="col-md-3 info">
                                <span class="lnr lnr-menu-circle"></span>
                            </div>
                            <div class="col-md-3 info">
                                <span class="lnr lnr-bubble"></span>
                            </div> 
                            <div class="col-md-3 info">
                                <span class="lnr lnr-pushpin"></span>
                            </div>
                        </div>
                        <asp:TextBox ID="txtIcon" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>系统菜单等级:</label>
                        <asp:DropDownList ID="ddlFirst" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlFirst_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="1">一级菜单</asp:ListItem>
                            <asp:ListItem Value="2">二级菜单</asp:ListItem>
                            <asp:ListItem Value="3">三级菜单</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlSecond" runat="server" CssClass="form-control" Style="display: none;" OnSelectedIndexChanged="ddlSecond_OnSelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        <asp:DropDownList ID="ddlThird" runat="server" CssClass="form-control" Style="display: none;"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="保存" CssClass="btn btn-primary" />
                        <asp:Button ID="btnReset" OnClick="btnReset_Click" runat="server" Text="重置" CssClass="btn btn-danger" />
                    </div>
                </div>
            </div>


        </div>
    </div>

    <script>

        $(".info").click(function (data)
        {
            var icon = $(this).children().attr('class');
            $("#ContentPlaceHolder2_txtIcon").val(icon);
        })

    </script>

</asp:Content>
