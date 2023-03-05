<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="MedicalCenter.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="LoginSheet.css" rel="stylesheet" />
    <script type="text/javascript">
        function showpw() {
            var passwordInput = document.getElementById("PassWord");
            if (passwordInput.type === "password") {
                passwordInput.type = "text";
            } else {
                passwordInput.type = "password";
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-box">
            <div class="usernamerow">
                <asp:Label Text="User Name" CssClass="lbluname" runat="server"></asp:Label>
                <asp:TextBox ID="UserName" CssClass="txtuname" runat="server"></asp:TextBox>
            </div>
            <div class="pwrow">
                <asp:Label Text="Password" CssClass="lblpw" runat="server"></asp:Label>
                <asp:TextBox ID="PassWord" CssClass="txtpw" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div class="showpw">
                <input type="checkbox" id="showPassword" runat="server" onclick="showpw()" /> show password
            </div>
            <div class="msgbox">
                <asp:Label ID="message" runat="server" CssClass="lblmsg" Text=""></asp:Label>
            </div>
            <div class="btnsrow">
                <asp:Button ID="Login" CssClass="btnlogin" runat="server" OnClick="Login_Click" Text="Login" />
            </div>
        </div>
    </form>
</body>
</html>
