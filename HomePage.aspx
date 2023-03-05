<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="MedicalCenter.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link href="HomeSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="box" runat="server">
            <div class="userinforow" runat="server">
                <asp:Label ID="lblwelcome" CssClass="lblwlcm" runat="server" Text=""></asp:Label>
            </div>

            <div class="yourpatients" runat="server">
                <asp:Label ID="lblyourpat" runat="server" CssClass="lblyourpat" Text="Doctor Patient List"></asp:Label>
                <asp:Label ID="empty" runat="server" CssClass="lblempty" Text=""></asp:Label>

                <asp:GridView ID="tblyourpat" runat="server" CssClass="tblyp">
                </asp:GridView>
            </div>
            <div class="allpatients" runat="server">
                <asp:Label ID="lblallpat" runat="server" CssClass="lblallpat" Text="All Patients List"></asp:Label>
                <asp:GridView ID="tblallpat" runat="server" CssClass="tblap" OnSelectedIndexChanged="tblallpat_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" SelectText="Add to your patients" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="btns">
                <asp:Button ID="btnlgout" runat="server" CssClass="btnlogout" OnClick="btnlgout_Click" Text="Log Out" />
            </div>
        </div>
    </form>
</body>
</html>
