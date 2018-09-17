Imports System.Data.SqlClient

Public Class MENU
    Inherits System.Web.UI.Page

    Dim cboEkranlarSelectedValue As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cboEkranlarSelectedValue = cboEkranlar.SelectedValue.ToString()
        Dim MODUL As String = Request.QueryString("modul")
        Dim KULLANICI_BILGILERI As String() = Request.Cookies.Get("KULLANICI_BILGILERI_COOKIE").Value.ToString().TrimStart("_").Split("_")
        Dim conn As SqlConnection = New SqlConnection("Server=.;trusted_connection=false;uid=sa;pwd=0000;database=YetkiDB_2")
        conn.Open()
        Dim sql As String = "SELECT *FROM KULLANICI WHERE MODUL = '" & MODUL & "' AND KULLANICI_ADI = '" & KULLANICI_BILGILERI(0) & "' AND PAROLA = '" & KULLANICI_BILGILERI(1) & "'"
        Dim cmd As SqlCommand = New SqlCommand(sql, conn)
        cboEkranlar.DataSource = cmd.ExecuteReader()
        cboEkranlar.DataBind()
    End Sub

    Protected Sub cboEkranlar_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim SCRIPT As String = "window.open('" & cboEkranlarSelectedValue + "', '_blank', 'EKRAN_WINDOW', 'width=300,height=100,left=100,top=100,resizable=yes');"
        ClientScript.RegisterStartupScript(Me.GetType(), "script", SCRIPT, True)
    End Sub

End Class