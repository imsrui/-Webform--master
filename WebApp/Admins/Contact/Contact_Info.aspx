<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/shared/_Backend.Master" AutoEventWireup="true" CodeBehind="Contact_Info.aspx.cs" Inherits="WebApp.Admins.Contact.Contact_Info" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>编辑联系我们</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row">
        <div class="col-md-offset-1 col-md-10">
            <div class="panel">
                <div class="panel-heading">
                    <h3 class="panel-title">编辑联系我们</h3>
                </div>
                <div class="panel-body">
                    <asp:HiddenField ID="hfContactId" runat="server" />
                    <div class="form-group">
                        <label>联系我们地址:</label>
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>联系我们电话:</label>
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>联系我们QQ1:</label>
                        <asp:TextBox ID="txtQQ1" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>联系我们QQ2:</label>
                        <asp:TextBox ID="txtQQ2" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>联系我们微信:</label>
                        <asp:TextBox ID="txtWeiXin" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>联系我们微博:</label>
                        <asp:TextBox ID="txtWeiBo" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>联系我们传真:</label>
                        <asp:TextBox ID="txtFax" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>联系我们电子邮件:</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>工作时间:</label>
                        <asp:TextBox ID="txtWorkTime" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div>
                        <label>二维码图片:</label>
                        <asp:Image ID="Image1" runat="server" />
                        <asp:FileUpload ID="FileUpload1" CssClass="form-control" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="保存" CssClass="btn btn-primary" />
                        <asp:Button ID="btnReset" OnClick="btnReset_Click" runat="server" Text="重置" CssClass="btn btn-danger" />
                    </div>
                </div>
            </div>


        </div>
    </div>
</asp:Content>
