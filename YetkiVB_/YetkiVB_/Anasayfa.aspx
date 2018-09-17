<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Anasayfa.aspx.vb" Inherits="YetkiVB_.Anasayfa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <div>
            Merhaba <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>,
            <br />
            Burası Anasayfa
            <br />
            <br />
            <asp:Button ID="btnSatışModülü" runat="server" Text="SATIŞ" OnClick="MenüyüAç" CommandName="SATIS" Font-Bold="True" Height="50px" Width="250px" />
           <br />                      
            <asp:Button ID="btnMuhasebeModülü" runat="server" Text="MUHASEBE" OnClick="MenüyüAç" CommandName="MUHASEBE" Font-Bold="True" Height="50px" Width="250px" />
            <br />                       
            <asp:Button ID="btnÜretimModülü" runat="server" Text="ÜRETİM" OnClick="MenüyüAç" CommandName="URETIM" Font-Bold="True" Height="50px" Width="250px" />
             <br />
            <asp:Button ID="btnSatınalma" runat="server" Text="SATINALMA" OnClick="MenüyüAç" CommandName="SATINALMA" Font-Bold="True" Height="50px" Width="250px" />
            <br />
            <asp:Button ID="btnOturumuKapat" runat="server" Text="OTURUMU KAPAT" OnClick="MenüyüAç" Font-Bold="True" Height="50px" Width="250px"/>
            
        </div>
         <asp:Label ID="lblMesaj" runat="server" Font-Bold="True" Font-Size="X-Large" Font-Strikeout="False" Font-Underline="True"></asp:Label>
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Timer ID="Timer1" Interval="5000" runat="server" OnTick="Timer1_Tick" OnInit="Timer1_Init"></asp:Timer>
    </form>
</body>
</html>
