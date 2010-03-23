<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogOnView.aspx.cs" Inherits="FuBuPlanner.Web.Controllers.Accounts.LogOnView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input type="text" name="LogOnIdentifier" value="<%= Model.LogOnIdentifier %>" />
        <input type="hidden" name="ReturnUrl" value="<%= Model.ReturnUrl ?? "Home/Home" %>" />
        <ul>
        <% foreach (var error in Model.Errors)
           { %>
           <li><%= error.Value %></li>
        <% } %>
        </ul>
    </div>
    </form>
</body>
</html>
