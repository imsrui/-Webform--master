<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/shared/_Backend.Master" AutoEventWireup="true" CodeBehind="About_List.aspx.cs" Inherits="WebApp.Admins.About.About_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>编辑关于我们</title>
    <script charset="utf-8" src="../../kindeditor/kindeditor.js" type="text/javascript"></script>
    <script charset="utf-8" src="../../kindeditor/lang/zh_CN.js" type="text/javascript"></script>
    <script charset="utf-8" src="../../kindeditor/plugins/code/prettify.js" type="text/javascript"></script>
    <script type="text/javascript">
        KindEditor.ready(function (K) {
            var editor1 = K.create('#ContentPlaceHolder2_txtAboutContent', {
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
  

</asp:Content>
