<%@ Page Title="" Language="C#" MasterPageFile="~/Web/shared/Frontend.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApp.Web.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=title %></title>
    <meta name="keyword" content="<%=keyword %>"/>
    <meta name="description" content="<%=description %>"/>
    <script>
        $(function()
        {
            $(".nav_r>ul>li:eq(0)").addClass("cur");
        });
       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="index_1">
        <asp:Repeater ID="RepLoanTypeList" runat="server">
            <ItemTemplate>
                <li class='index_1<%#Container.ItemIndex+1 %>'>
                    <p><%#Eval("LoanType_Title") %></p>
                    <b><%#Eval("LoanType_Detail").ToString().Length > 25 ? 
                              Eval("LoanType_Detail").ToString().Substring(0,25)+"..." :
                              Eval("LoanType_Detail")%></b>
                </li>

            </ItemTemplate>
        </asp:Repeater>

        <div class="clear"></div>
    </ul>
    <div class="index_2">
        <div class="index_21">新闻资讯</div>
        <div class="index_22"><a href="NewsList.aspx">
            <img src="assets/images/index_22.png" width="34" height="43" /></a></div>
        <div class="clear"></div>
        <div class="index_23">
            <img src="assets/images/index_3.png" width="272" height="185" /></div>
        <ul class="index_24">
            <asp:Repeater ID="RepNewsList" runat="server">
                <ItemTemplate>
                    <li><a href='NewsInfo.aspx?id=<%#Eval("News_Id") %>'><%#Eval("News_Title") %></a><span><%#DateTime.Parse(Eval("News_CreateTime").ToString()).ToString("yyyy/MM/dd") %></span></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
        <div class="clear"></div>
        <div class="index_25">
            <a href="NewsList.aspx">查看更多&nbsp;&gt;&gt;</a>
        </div>
    </div>


</asp:Content>
