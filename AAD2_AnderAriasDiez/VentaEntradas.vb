Imports System.IO

Public Class VentaEntradas
    Private pelicula As Pelicula
    Public Sub Mostrar(pelicula As Pelicula)
        Me.pelicula = pelicula
        Me.Show()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim entradas As Integer = NumericUpDown1.Value
        If (entradas > pelicula.pEntradasDisponibles) Then
            MessageBox.Show("No puedes comprar mas entradas de las disponibles, solo quedan " & pelicula.pEntradasDisponibles)
            Exit Sub
        ElseIf (entradas > 10) Then
            MessageBox.Show("No puedes comprar mas de 10 entradas")
            Exit Sub
        ElseIf (entradas <= 0) Then
            MessageBox.Show("Debes comprar al menos 1 entrada.")
            Exit Sub
        Else
            ActualizaEntradasEnBD(entradas)
            GuardarVentaEnFichero(entradas)
            pelicula.pEntradasDisponibles -= entradas
            MessageBox.Show("Compra realizada correctamente.")
            Me.Close()
        End If

    End Sub

    Private Sub GuardarVentaEnFichero(cantidad As Integer)
        Dim ruta As String = Application.StartupPath & "..\..\..\..\ventas.txt"

        Using sw As New StreamWriter(ruta, True)
            sw.WriteLine("----------------------------------------")
            sw.WriteLine("PELÍCULA: " & pelicula.pTitulo)
            sw.WriteLine("Año de estreno: " & pelicula.pEstreno)
            sw.WriteLine("Duración: " & pelicula.pDuracion & " minutos")
            sw.WriteLine("Entradas vendidas: " & cantidad)
            sw.WriteLine("Entradas restantes: " & pelicula.pEntradasDisponibles)
            sw.WriteLine("Sinopsis: " & pelicula.pSinopsis)
            sw.WriteLine("----------------------------------------")
            sw.WriteLine()
        End Using
    End Sub



    Private Sub ActualizaEntradasEnBD(cantidad As Integer)
        Dim conexion As New SqlClient.SqlConnection("Server=localhost\SQLEXPRESS;Database=CINE;Integrated Security=True")

        Dim consulta As String = "UPDATE PELICULA SET EntradasDisponibles = EntradasDisponibles - @cantidad WHERE Titulo = @titulo"

        Dim comando As New SqlClient.SqlCommand(consulta, conexion)
        comando.Parameters.AddWithValue("@cantidad", cantidad)
        comando.Parameters.AddWithValue("@titulo", pelicula.pTitulo)

        conexion.Open()
        comando.ExecuteNonQuery()
        conexion.Close()
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class