<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="YetkiVB_.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtKullaniciAdi" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtParola" runat="server"></asp:TextBox>
            <asp:Button ID="btnGirişYap" runat="server" Text="Button" OnClick="btnGirişYap_Click" />
        </div>
    </form>
</body>
</html>
