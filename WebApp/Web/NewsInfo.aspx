<%@ Page Title="" Language="C#" MasterPageFile="~/Web/shared/Frontend.Master" AutoEventWireup="true" CodeBehind="NewsInfo.aspx.cs" Inherits="WebApp.Web.NewsInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>好信速贷--新闻详情</title>
    <script>
        $(function()
        {
            $(".nav_r>ul>li:eq(0)").addClass("cur");
        });
       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="xydk1">
        <p>新闻资讯</p>
        <div class="xydk1_2">News Information</div>
    </div>
    <div class="zx_xx">
        <div class="zx_xxbt"><%=title %></div>
        <div class="zx_xxtime"><%=time %></div>
        <div class="zx_xxwz">
           <p>
               <%=content %>
           </p>
        </div>
    </div>
    <div class="zx_zzqh">
        <p>上一篇：<span><a href="NewsInfo.aspx?id=<%=preLink %>"><%=preTitle %></a></span></p>
        <p>下一篇：<span><a href="NewsInfo.aspx?id=<%=nextLink %>"><%=nextTitle %></a></span></p>
    </div>
</asp:Content>
