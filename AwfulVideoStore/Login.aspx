<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AwfulVideoStore.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size: 50px">
        <asp:TextBox runat="server" ID="unTB" />
        <asp:TextBox runat="server" ID="passTB" TextMode="Password" />
        <asp:Button runat="server" OnClick="lgnButtnClck" Text="Log In"/>
    </div>
    </form>
</body>
</html>
