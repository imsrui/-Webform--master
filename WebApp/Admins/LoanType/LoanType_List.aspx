<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/shared/_Backend.Master" AutoEventWireup="true" CodeBehind="LoanType_List.aspx.cs" Inherits="WebApp.Admins.LoanType.LoanType_List" %>
<%@ Register Assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>贷款类型</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div class="row mb-1">
        <div class="col-md-10 col-md-offset-1">
            
            <div class="col-md-5">
                <%--<input type="text" class="form-control"/>--%>
                <asp:TextBox ID="txtSearch" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <%--<button class="btn btn-primary">Go</button>--%>
                <asp:Button ID="btnSearch" runat="server" Text="Go" CssClass="btn btn-primary" OnClick="btnSearch_OnClick" />
                <a href="LoanType_Add.aspx" class="btn btn-success">Insert</a>
                <button class="btn btn-danger">Delete</button>
            </div>

        </div>
    </div>
    
    <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <div class="panel">
                <div class="panel-heading">
                    <h3 class="panel-title">贷款类型表</h3>
                </div>
                <div class="panel-body">
                    <table class="table table-bordered table-hover">
                        <thead>
                            <tr>
                                <th width="5%">编号</th>
                                <th width="10%">类型名称</th>
                                <th width="10%">类型描述</th>
                                <th width="10%">类型图片</th>
                                <th width="5%">编辑</th>
                                <th width="5%">删除</th>

                            </tr>

                        </thead>
                        <tbody>
                        <asp:Repeater ID="RepLoanTypeList" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%#Container.ItemIndex+1 %></td>
                                     <td>
                                         <%#Eval("LoanType_Title") %>
                                     </td>  
                                    <td>
                                        <%#Eval("LoanType_Detail") %>
                                    </td> 
                                    <td>
                                        <img src='../../upload/loantype/<%#Eval("LoanType_Image") %>'/>
                                    </td>
                                    <td>
                                        <a class="btn btn-warning" href='LoanType_Edit.aspx?action=<%#Eval("LoanType_Id") %>'>
                                            <span class="lnr lnr-pencil"></span> 修改
                                        </a>
                                    </td>
                                    <td>
                                        <a class="btn btn-danger" href='LoanType_Remove.aspx?action=<%#Eval("LoanType_Id") %>'>
                                            <span class="lnr lnr-trash"></span> 删除
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
    

</asp:Content>
