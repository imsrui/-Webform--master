<%@ Page Title="" Language="C#" MasterPageFile="~/Web/shared/Frontend.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebApp.Web.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>好信速贷--联系我们</title>
    <script>
        $(function()
        {
            $(".nav_r>ul>li:eq(7)").addClass("cur");
        });
       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="xydk1">
        <p>联系我们</p>
        <div class="xydk1_2">Contact us</div>
    </div>
    <div class="dt">
        <iframe src="map.htm" width="1000" height="500"></iframe>
    </div>

    <div class="lxwm_1">
        <p>联系电话:<%=tel %></p>
        <p>传真电话:<%=fax %></p>
        <p>公司邮箱：<%=email %></p>
        <p>公司地址：<%=address %></p>
    </div>
</asp:Content>
