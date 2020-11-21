<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/shared/_Backend.Master" AutoEventWireup="true" CodeBehind="Examine_Edit.aspx.cs" Inherits="WebApp.Admins.Order.Examine_Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>编辑预约审核信息</title>
    <script charset="utf-8" src="../../kindeditor/kindeditor.js" type="text/javascript"></script>
    <script charset="utf-8" src="../../kindeditor/lang/zh_CN.js" type="text/javascript"></script>
    <script charset="utf-8" src="../../kindeditor/plugins/code/prettify.js" type="text/javascript"></script>
    <script type="text/javascript">
        KindEditor.ready(function (K) {
            var editor1 = K.create('#ContentPlaceHolder2_txtExamineContent', {
                cssPath: '../../kindeditor/plugins/code/prettify.css',
                uploadJson: './kindeditor/asp.net/upload_json.ashx',
                fileManagerJson: './kindeditor/asp.net/file_manager_json.ashx',
                allowFileManager: true,
                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                }
            });
            prettyPrint();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row">
        <div class="col-md-offset-1 col-md-10">
            <div class="panel">
                <div class="panel-heading">
                    <h3 class="panel-title">编辑审核信息</h3>
                </div>
                <div class="panel-body">
                    <asp:HiddenField ID="hfOrderId" runat="server" />
                    <asp:HiddenField ID="hfExamineId" runat="server" />
                    <div class="form-group">
                        <label>预约人姓名:</label>
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div>
                        <label>审核结果:</label>
                        <asp:DropDownList ID="ddlResult" runat="server" CssClass="form-control">
                            <asp:ListItem Value="审核未通过">审核未通过</asp:ListItem>
                            <asp:ListItem Value="审核通过">审核通过</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>原因:</label>
                        <textarea id="txtExamineContent" cols="100" rows="15" style="width:821px;height:400px;visibility:hidden;" runat="server"></textarea>
                    </div>
                
                    <div class="form-group">
                        <asp:Button ID="btnSubmit" OnClick="btnSubmit_OnClick" runat="server" Text="提交" CssClass="btn btn-primary" />
                        <asp:Button ID="btnReset" OnClick="btnReset_OnClick" runat="server" Text="重置" CssClass="btn btn-danger" />
                    </div>
                </div>
            </div>
            

        </div>
    </div>
</asp:Content>
