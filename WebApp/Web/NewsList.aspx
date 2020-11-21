<%@ Page Title="" Language="C#" MasterPageFile="~/Web/shared/Frontend.Master" AutoEventWireup="true" CodeBehind="NewsList.aspx.cs" Inherits="WebApp.Web.NewsList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>好信速贷--新闻列表页</title>
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
<div class="zx">
  <ul>
      <asp:Repeater ID="RepNewsList" runat="server">
          <ItemTemplate>
              <li>
                  <div class="zx_left"><a href='NewsInfo.aspx?id=<%#Eval("News_Id") %>'><%#Eval("News_Title") %></a></div>
                  <div class="zx_right"><a href='NewsInfo.aspx?id=<%#Eval("News_Id") %>'><%#DateTime.Parse(Eval("News_CreateTime").ToString()).ToString("yyyy-MM-dd") %></a></div>
              </li>
          </ItemTemplate>

      </asp:Repeater>
    <%--<li>
      <div class="zx_left"><a href="#">全园运动 趣味恒生 ——2014恒生科技园首届创意交流趣味运动会圆满落幕</a></div>
      <div class="zx_right"><a href="#">2014-08-05</a></div>
    </li>
    <li>
      <div class="zx_left"><a href="#">广西涠洲岛群体事件还原：千人聚集要求分上岛费</a></div>
      <div class="zx_right"><a href="#">2014-08-05</a></div>
    </li>
    <li>
      <div class="zx_left"><a href="#">最高人民检察院对江西省原副省长姚木根立案侦查</a></div>
      <div class="zx_right"><a href="#">2014-08-05</a></div>
    </li>
    <li>
      <div class="zx_left"><a href="#">Apple TV新测试版发布: 采用扁平风格图标</a></div>
      <div class="zx_right"><a href="#">2014-08-05</a></div>
    </li>
    <li>
      <div class="zx_left"><a href="#">苹果手机: 无锁苹果iphone5S不到4K A7双核指纹识别</a></div>
      <div class="zx_right"><a href="#">2014-08-05</a></div>
    </li>
    <li>
      <div class="zx_left"><a href="#">惠普台式机: 四代i3芯2G独显,惠普Pavilion 500</a></div>
      <div class="zx_right"><a href="#">2014-08-05</a></div>
    </li>
    <li>
      <div class="zx_left"><a href="#">iPhone技巧篇 天气应用如何查看更多指数</a></div>
      <div class="zx_right"><a href="#">2014-08-05</a></div>
    </li>
    <li>
      <div class="zx_left"><a href="#">美国发现系外行星比预想更干燥 或挑战现有理论</a></div>
      <div class="zx_right"><a href="#">2014-08-05</a></div>
    </li>
    <li>
      <div class="zx_left"><a href="#">小米手机4评测：雷军服了再也不跑分了</a></div>
      <div class="zx_right"><a href="#">2014-08-05</a></div>
    </li>
    <li>
      <div class="zx_left"><a href="#">惠普起诉Autonomy前CFO 指控其插手公司内部事务</a></div>
      <div class="zx_right"><a href="#">2014-08-05</a></div>
    </li>--%>
    <div class="clear"></div>
  </ul>
</div>
<div class="fy">
  <div class="gyhd_fy">
      <ul>
          <webdiyer:AspNetPager ID="AspNetPager1" CssClass="pages" CurrentPageButtonClass="cpb"
                                CustomInfoTextAlign="Right" HorizontalAlign="Right" ShowCustomInfoSection="Left"
                                ShowMoreButtons="false" ShowNavigationToolTip="false" ShowFirstLast="false" NumericButtonCount="5"
                                EnableTheming="True" runat="server" AlwaysShow="True" PageSize="10" LayoutType="Table"
                                OnPageChanging="AspNetPager1_OnPageChanging" PagingButtonSpacing="2px" CustomInfoSectionWidth="">
          </webdiyer:AspNetPager>
               
          <div class="clear">
          </div>
      </ul>
  </div>
  <div class="clear"></div>
</div>
</asp:Content>
