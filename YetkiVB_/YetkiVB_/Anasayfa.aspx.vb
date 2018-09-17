Imports System.Data.SqlClient

Public Class Anasayfa
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim kullanici = HttpContext.Current.User.Identity.Name
        Label1.Text = kullanici
    End Sub

    Protected Sub MenüyüAç(sender As Object, e As EventArgs) Handles btnÜretimModülü.Click
        Dim SAYFA As String = CType(sender, Button).CommandName
        Dim KULLANICI_BILGILERI As String() = Request.Cookies.Get("KULLANICI_BILGILERI_COOKIE").Value.ToString().TrimStart("_").Split("_")
        Dim conn As SqlConnection = New SqlConnection("Server=.;trusted_connection=false;uid=sa;pwd=0000;database=YetkiDB_2")
        conn.Open()
        Dim sql As String = "SELECT TOP 1 *FROM KULLANICI WHERE KULLANICI_ADI = '" & KULLANICI_BILGILERI(0) & "' AND PAROLA = '" & KULLANICI_BILGILERI(1) & "' AND MODUL = '" & SAYFA & "'"
        Dim cmd As SqlCommand = New SqlCommand(sql, conn)
        Dim dr As SqlDataReader = cmd.ExecuteReader()

        Dim MODULE_GIRIS_YETKISI_VARMI As Boolean = False

        While dr.Read()
            MODULE_GIRIS_YETKISI_VARMI = True
        End While

        If MODULE_GIRIS_YETKISI_VARMI = False Then
            lblMesaj.Text = "BU MODÜLE GİRİŞ YETKİNİZ YOK!"
            Timer1.Enabled = True

        Else
            Dim url As String = "MENU.aspx?modul=" & SAYFA
            Dim s As String = "window.open('" & url + "', 'MENU_WINDOW', 'width=300,height=500,left=100,top=100,resizable=yes');"
            ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)
        End If

    End Sub

    Protected Sub Timer1_Init(sender As Object, e As EventArgs)

    End Sub

    Protected Sub Timer1_Tick(sender As Object, e As EventArgs)
        lblMesaj.Text = ""
        Timer1.Enabled = False
    End Sub
End Class