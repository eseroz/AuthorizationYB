<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MENU.aspx.vb" Inherits="YetkiVB_.MENU" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="cboEkranlar" runat="server" DataTextField="EKRAN" DataValueField="URL" Width="270px" OnSelectedIndexChanged="cboEkranlar_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        </div>
    </form>
</body>
</html>
