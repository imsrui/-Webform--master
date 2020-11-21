<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/shared/_Backend.Master" AutoEventWireup="true" CodeBehind="News_List.aspx.cs" Inherits="WebApp.Admins.News.News_List" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>新闻列表</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row mb-1">
        <div class="col-md-10 col-md-offset-1">

            <div class="col-md-5">

                <asp:TextBox ID="txtSearch" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:Button ID="btnSearch" runat="server" Text="Go" CssClass="btn btn-primary" OnClick="btnSearch_OnClick" />
                <a href="News_Add.aspx" class="btn btn-success">Insert</a>
                <button class="btn btn-danger">Delete</button>
            </div>

        </div>
    </div>

    <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <div class="panel">
                <div class="panel-heading">
                    <h3 class="panel-title">权限表</h3>
                </div>
                <div class="panel-body">
                    <table class="table table-bordered table-hover">
                        <thead>
                            <tr>
                                <th width="5%">编号</th>
                                <th width="10%">新闻名称</th>
                                <th width="10%">新闻内容</th>
                                <th width="10%">新闻图片</th>
                                <th width="5%">编辑</th>
                                <th width="5%">删除</th>

                            </tr>

                        </thead>
                        <tbody>
                            <asp:Repeater ID="RepNewsList" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Container.ItemIndex+1 %></td>
                                        <td>
                                            <%#Eval("News_Title") %>
                                        </td>
                                        <td>
                                            <%#Eval("News_Content").ToString().Length > 50 ? Eval("News_Content").ToString().Substring(0,50)+"..." : Eval("News_Content").ToString()  %>
                                        </td>
                                        <td>
                                           
                                            <img src='../../upload/news/<%#Eval("News_Image") %>' alt="没有图片" />

                                        </td>
                                        <td>
                                            <a class="btn btn-warning" href='News_Edit.aspx?action=<%#Eval("News_Id") %>'>
                                                <span class="lnr lnr-pencil"></span>修改
                                            </a>
                                        </td>
                                        <td>
                                            <a class="btn btn-danger" href='News_Remove.aspx?action=<%#Eval("News_Id") %>'>
                                                <span class="lnr lnr-trash"></span>删除
                                            </a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>

                        </tbody>


                    </table>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-10 col-md-offset-1">

            <div class="pagin">
                <webdiyer:AspNetPager ID="AspNetPager1" CssClass="pages" CurrentPageButtonClass="cpb"
                    CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页，每页%PageSize%条"
                    CustomInfoTextAlign="Left" HorizontalAlign="Right" PageIndexBoxType="TextBox"
                    ShowCustomInfoSection="Left" ShowMoreButtons="False" ShowNavigationToolTip="True"
                    runat="server" AlwaysShow="True" PageSize="8" ShowInputBox="Never"
                    LayoutType="Table" OnPageChanging="AspNetPager1_OnPageChanging"
                    FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页"
                    PagingButtonSpacing="2px" SubmitButtonClass="btngo">
                </webdiyer:AspNetPager>
            </div>


        </div>
    </div>
    
    <script>
        

    </script>
</asp:Content>
