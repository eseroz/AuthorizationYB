Imports System.Data.SqlClient

Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnGirişYap_Click(sender As Object, e As EventArgs)

        Dim loginAd = txtKullaniciAdi.Text
        Dim parola = txtParola.Text
        Dim conn As SqlConnection = New SqlConnection("Server=.;trusted_connection=false;uid=sa;pwd=0000;database=YetkiDB_2")
        conn.Open()
        Dim sql As String = "SELECT *FROM KULLANICI WHERE KULLANICI_ADI = '" & loginAd & "' AND PAROLA = '" & parola & "'"
        Dim cmd As SqlCommand = New SqlCommand(sql, conn)
        Dim rd As SqlDataReader = cmd.ExecuteReader()

        Dim KULLANICI_BILGILERI As HttpCookie = New HttpCookie("KULLANICI_BILGILERI_COOKIE", loginAd & "_" & parola)
        Response.Cookies.Add(KULLANICI_BILGILERI)

        If rd.Read() Then

            Dim ticket As FormsAuthenticationTicket = New FormsAuthenticationTicket(1, loginAd, DateTime.Now, DateTime.Now.AddMinutes(30), False, parola, FormsAuthentication.FormsCookiePath)
            Dim encTicket As String = FormsAuthentication.Encrypt(ticket)
            Dim cookie As HttpCookie = New HttpCookie(FormsAuthentication.FormsCookieName, encTicket)
            If ticket.IsPersistent Then
                cookie.Expires = ticket.Expiration
            End If
            Response.Cookies.Add(cookie)

            If Request.QueryString("ReturnUrl") = "" Then
                Response.Redirect("~/Anasayfa.aspx")
            Else
                Response.Redirect(Request.QueryString("ReturnUrl"))
            End If

        Else
            Response.Write("Hatalı kullanıcı adı veya parola.")
            Return
        End If


    End Sub
End Class