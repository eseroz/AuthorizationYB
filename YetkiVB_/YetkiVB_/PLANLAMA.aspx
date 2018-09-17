<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PLANLAMA.aspx.vb" Inherits="YetkiVB_.PLANLAMA" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            PLANLAMA MODÜLÜNE HOŞGELDİNİZ
        </div>        
        <asp:Button ID="btnKaydet" runat="server" Text="Kaydet" OnClick="btnKaydet_Click" />
        <br />
        <asp:Button ID="btnSil" runat="server" Text="Sil" OnClick="btnSil_Click" />
        <br />
        <asp:Button ID="btnAnasayfa" runat="server" Text="Anasayfa ya git" OnClick="btnAnasayfa_Click" />
    </form>
</body>
</html>
