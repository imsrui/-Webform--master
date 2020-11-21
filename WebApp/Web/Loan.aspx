<%@ Page Title="" Language="C#" MasterPageFile="~/Web/shared/Frontend.Master" AutoEventWireup="true" CodeBehind="Loan.aspx.cs" Inherits="WebApp.Web.Loan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=title %></title>
    <meta name="keyword" content="<%=keyword %>"/> 
    <meta name="description" content="<%=description %>"/>
    <script>
        $(function () {
            var url = window.location.href;
            var type = url.substring(url.lastIndexOf('=') + 1);
            if (type == "credit") {
                $(".nav_r>ul>li:eq(1)").addClass("cur");
            } else if (type == "house") {
                $(".nav_r>ul>li:eq(2)").addClass("cur");
            } else if (type == "car") {
                $(".nav_r>ul>li:eq(3)").addClass("cur");
            } else if (type == "company") {
                $(".nav_r>ul>li:eq(4)").addClass("cur");
            } else if (type == "person") {
                $(".nav_r>ul>li:eq(5)").addClass("cur");
            }
            

           
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="xydk1">
        <p><%=title %></p>
        <div class="xydk1_2">Credit loan</div>
    </div>
    <div class="xydk2">
        <div class="xydk21">
            <p>1.产品介绍</p>
            <span>Product introduction</span>
        </div>
        <div class="xydk22">
            <p><%=productDetail %></p>
        </div>
        <div class="clear"></div>
    </div>
    <div class="xydk3">
        <p>2.贷款条件</p>
        <span>Loan conditions</span>
    </div>
    <ul class="xydk4">
        <asp:Repeater ID="RepChoose" runat="server">
            <ItemTemplate>
                <li>
                    <div class="xydk4_1">
                        <img src="assets/images/xydk4<%#(Container.ItemIndex+1)*2-1 %>.png" width="86" height="10" />
                    </div>
                    <div>
                        <div class="xydk4_2<%#Container.ItemIndex+1 %>"><%#Container.ItemIndex+1 %></div>
                        <div class="xydk4_3">
                            <p class="wordwrap"><%#Eval("LoanChoose_Detail") %></p>
                        </div>
                        <div class="clear"></div>
                    </div>
                    <div class="xydk4_1">
                        <img src="assets/images/xydk4<%#(Container.ItemIndex+1)*2 %>.png" width="86" height="10" /></div>
                </li>
            </ItemTemplate>
        </asp:Repeater>
        <div class="clear"></div>
    </ul>
    <script type="text/javascript">
        $(function () {
            $(".xydk4_3").hover(function () {
                var _pw = $(this).find(".wordwrap").width();
                if (_pw > 735) {
                    $(this).find(".wordwrap").stop(true, true).animate({ "left": 735 - _pw }, 2000);
                }
            }, function () {
                $(this).find(".wordwrap").stop(true, true).animate({ "left": 0 }, 2000);
            })
        })
    </script>
    <div class="xydk5">
        <div class="xydk5_l">
            <p>3.申请资料</p>
            <span>Application materials</span>
        </div>
        <ul class="xydk5_r">
            <li><span>1</span>身份证复印件</li>
            <li><span>2</span>工资卡银行流水</li>
            <li><span>3</span>央行信用报告</li>
            <div class="clear"></div>
        </ul>
        <div class="clear"></div>
    </div>
    <div class="xydk6">
        <p>费用说明</p>
        <span>Explanation of cost</span>
    </div>
    <div class="xydk7">
        <p>平台服务费即平台向借款人收取的服务总费用，其中包含前期服务费、分期服务费两部分。信用资质良好的用户可免收分期服务费。</p>
        <p>前期服务费：借款人通过审核后放款前会一次性扣除的服务费为前期服务费。</p>
        <p>分期服务费：借款人除前期服务费以外需要按月缴纳的服务费。</p>
        <p>&nbsp;</p>
        <p>其他费用：</p>
        <p>
            身份验证费用：借款人身份验证7次不通过则需收取5元/次的身份验证费用。<p>
                <p>审核费用：借款人提交借款申请单后需支付15元/单的信用审核费用。</p>
            </p>
    </div>
</asp:Content>
