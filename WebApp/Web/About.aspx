<%@ Page Title="" Language="C#" MasterPageFile="~/Web/shared/Frontend.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApp.Web.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>关于我们</title>
    <script>
        $(function()
        {
            $(".nav_r>ul>li:eq(6)").addClass("cur");
        });
       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="xydk1">
        <p>关于我们</p>
        <div class="xydk1_2">Contact us</div>
    </div>
    <div class="zx_xx">
        <div class="zx_xxbt"><%=title %></div>
        <div class="zx_xxtime"><%=time %></div>
        <div class="zx_xxwz">
           <%=content %>
        </div>
    </div>
</asp:Content>
