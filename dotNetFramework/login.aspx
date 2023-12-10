<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="dotNetFramework.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label>Login ID</label><br />
            <asp:TextBox ID="username" TextMode="SingleLine" runat="server" /><br /><br />
            <label>Password</label><br />
            <asp:TextBox ID="password" TextMode="Password" runat="server" /><br /><br />
            <asp:Button ID="btn" runat="server" type="button" Text="Sign In" Width="167px" OnClick="btn_Click" /><br /><br />
            <%--<asp:Label ID="lblMsg" runat="server" Text="" /><br />--%>
        </div>
    </form>
</body>
</html>
