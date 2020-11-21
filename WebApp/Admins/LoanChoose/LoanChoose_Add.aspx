<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/shared/_Backend.Master" AutoEventWireup="true" CodeBehind="LoanChoose_Add.aspx.cs" Inherits="WebApp.Admins.LoanChoose.LoanChoose_Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>新增贷款条件</title>
    <script charset="utf-8" src="../../kindeditor/kindeditor.js" type="text/javascript"></script>
    <script charset="utf-8" src="../../kindeditor/lang/zh_CN.js" type="text/javascript"></script>
    <script charset="utf-8" src="../../kindeditor/plugins/code/prettify.js" type="text/javascript"></script>
    <script type="text/javascript">
        KindEditor.ready(function (K) {
            var editor1 = K.create('#ContentPlaceHolder2_txtLoanChooseContent', {
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
                    <h3 class="panel-title">新增贷款条件</h3>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label>贷款类型:</label>
                        <asp:DropDownList ID="ddlLoanType" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>贷款条件内容:</label>
                        <textarea id="txtLoanChooseContent" cols="100" rows="15" style="width:821px;height:400px;visibility:hidden;" runat="server"></textarea>
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
