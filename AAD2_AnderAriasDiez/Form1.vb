Public Class Form1
    Private peliculas As New List(Of Pelicula)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarPeliculas()
        PictureBox1.Image = CargarImagen(peliculas(0).pUrlImagen)
        PictureBox2.Image = CargarImagen(peliculas(1).pUrlImagen)
        PictureBox3.Image = CargarImagen(peliculas(2).pUrlImagen)
        PictureBox4.Image = CargarImagen(peliculas(3).pUrlImagen)
        PictureBox5.Image = CargarImagen(peliculas(4).pUrlImagen)
    End Sub

    Private Function CargarImagen(urlImagen As String) As Image
        Return CType(My.Resources.ResourceManager.GetObject(urlImagen), Image)
    End Function


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        InfoPeli.Mostrar(peliculas(0))
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        InfoPeli.Mostrar(peliculas(1))
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        InfoPeli.Mostrar(peliculas(2))
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        InfoPeli.Mostrar(peliculas(3))
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        InfoPeli.Mostrar(peliculas(4))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Creditos.Mostrar()
    End Sub
    Private Sub CargarPeliculas()
        Dim conexion As New SqlClient.SqlConnection("Server=localhost\SQLEXPRESS;Database=CINE;Integrated Security=True")
        Dim consulta As String = "SELECT * FROM PELICULA"

        Dim adaptador As New SqlClient.SqlDataAdapter(consulta, conexion)
        Dim ds As New DataSet()

        adaptador.Fill(ds, "PELICULA")

        For Each fila As DataRow In ds.Tables("PELICULA").Rows
            Dim p As New Pelicula(
            fila("Titulo").ToString(),
            CInt(fila("AnioEstreno")),
            CInt(fila("Duracion")),
            fila("Sinopsis").ToString(),
            fila("PosterUrl").ToString(),
            CInt(fila("EntradasDisponibles"))
        )

            peliculas.Add(p)
        Next
    End Sub

End Class
