<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/shared/_Backend.Master" AutoEventWireup="true" CodeBehind="Seos_Edit.aspx.cs" Inherits="WebApp.Admins.Seos.Seos_Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>编辑Seo优化信息</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row">
        <div class="col-md-offset-1 col-md-10">
            <div class="panel">
                <div class="panel-heading">
                    <h3 class="panel-title">编辑优化信息</h3>
                </div>
                <div class="panel-body">
                    <asp:HiddenField ID="hfSeosId" runat="server" />
                    <div class="form-group">
                        <label>优化名称:</label>
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>优化关键字:</label>
                        <asp:TextBox ID="txtKeyword" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>优化描述:</label>
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>优化网站菜单:</label>
                        <asp:DropDownList ID="ddlWebMenuId" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnSubmit" OnClick="btnSubmit_OnClick" runat="server" Text="保存" CssClass="btn btn-primary" />
                        <asp:Button ID="btnReset" OnClick="btnReset_OnClick" runat="server" Text="重置" CssClass="btn btn-danger" />
                    </div>
                </div>
            </div>
            

        </div>
    </div>
</asp:Content>
