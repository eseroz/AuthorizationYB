
Imports System.Data.SqlClient



Public Class Global_asax
    Inherits HttpApplication
    Protected Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        If HttpContext.Current.User IsNot Nothing Then
            If HttpContext.Current.User.Identity.IsAuthenticated Then
                If TypeOf HttpContext.Current.User.Identity Is FormsIdentity Then
                    Dim identity As FormsIdentity = CType(HttpContext.Current.User.Identity, FormsIdentity)
                    Dim ticket As FormsAuthenticationTicket = identity.Ticket
                    Dim roles As String() = ticket.UserData.Split(","c)
                    HttpContext.Current.User = New System.Security.Principal.GenericPrincipal(identity, roles)
                End If
            End If
        End If
    End Sub

    Protected Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    Protected Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    Protected Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        Dim application = (CType(sender, HttpApplication))
        Dim context = application.Context
        Dim filePath = context.Request.FilePath

        If filePath.Length = 0 Then
            Response.Redirect("~/Anasayfa.aspx")
        End If

        filePath = filePath.Substring(1, filePath.Length - 1)
        filePath = filePath.Substring(0, filePath.Length - 5)

        If filePath <> "Anasayfa" AndAlso filePath <> "Login" Then
            Dim KOMUT_YETKISI As Boolean = False
            Dim MODUL As String = filePath

            If context.Request.Form.AllKeys.Length = 4 Then
                Dim KOMUT As String = context.Request.Form.AllKeys(3)
                Dim conn As SqlConnection = New SqlConnection("Server=.;trusted_connection=false;uid=sa;pwd=0000;database=YetkiDB_2")
                conn.Open()

                Dim KULLANICI_BILGILERI As String() = Request.Cookies.Get("KULLANICI_BILGILERI_COOKIE").Value.ToString().TrimStart("_").Split("_")

                Dim sql As String = "SELECT *FROM KULLANICI WHERE KULLANICI_ADI = '" & KULLANICI_BILGILERI(0) & "' AND PAROLA = '" & KULLANICI_BILGILERI(1) & "' AND URL = '" & MODUL & ".aspx' AND  KOMUTLAR LIKE '%" & KOMUT & "%'"
                Dim cmd As SqlCommand = New SqlCommand(sql, conn)
                Dim dr As SqlDataReader = cmd.ExecuteReader()

                If dr.Read() Then
                    Dim X As String = dr(5).ToString()
                    Dim KOMUTLAR As String() = X.Split(";"c)
                    For Each KOMUT_ITEM In KOMUTLAR
                        If KOMUT = KOMUT_ITEM Then
                            KOMUT_YETKISI = True
                        End If
                    Next
                End If

                conn.Close()

                If KOMUT = "btnAnasayfa" Then
                    KOMUT_YETKISI = True
                End If

                If KOMUT_YETKISI = True Then
                    Response.Write(KOMUT & " KOMUTUNU KULLANDINIZ")
                Else
                    Response.Write("BU KOMUTU KULLANMA YETKİNİZ YOK!")
                End If
            End If
        End If
    End Sub

    Protected Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    Protected Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    Protected Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
    End Sub
End Class

