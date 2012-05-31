<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SSRSReport.aspx.cs" Inherits="SSRSReport"  Title="SSRS Report"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <rsweb:ReportViewer runat="server" ID="MyReportViewer" Width="100%" Height="700px">
        </rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>
