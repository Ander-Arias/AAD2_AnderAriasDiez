Imports System.Net.Http
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Creditos
    Private nombre As String
    Private repos As Integer
    Private foto As String
    Private url As String
    Private Shared ReadOnly client As HttpClient = New HttpClient()
    Public Async Sub Mostrar()
        Await LlamarAApi()
        lblNombre.Text = "Nombre: " & nombre
        lblRepos.Text = "Repositorios publicos :" & repos
        PictureBox1.ImageLocation = foto
        Me.Show()
    End Sub
    Public Shared Async Function LlamarAApi() As Task
        Try
            client.DefaultRequestHeaders.UserAgent.ParseAdd("VB-App")
            Dim url As String = "https://api.github.com/users/Ander-Arias"
            Dim respuesta As HttpResponseMessage = Await client.GetAsync(url)
            respuesta.EnsureSuccessStatusCode()
            Dim contenido As String = Await respuesta.Content.ReadAsStringAsync()
            Dim data As JObject = JsonConvert.DeserializeObject(Of JObject)(contenido)
            Creditos.nombre = data("login").ToString()
            Creditos.repos = data("public_repos").Value(Of Integer)
            Creditos.foto = data("avatar_url").ToString()
            Creditos.url = data("html_url").ToString()
        Catch ex As Exception
            MessageBox.Show("ERROR: " & ex.Message)
        End Try
    End Function
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Process.Start(New ProcessStartInfo(url) With {.UseShellExecute = True})
    End Sub
End Class