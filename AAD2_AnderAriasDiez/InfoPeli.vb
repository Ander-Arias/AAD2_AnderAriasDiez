Public Class InfoPeli
    Private pelicula As Pelicula
    Public Sub Mostrar(pelicula As Pelicula)
        lblTitulo.Text = pelicula.pTitulo
        lblEstreno.Text = "Año de estreno: " & pelicula.pEstreno
        lblDuracion.Text = "Duracion: " & pelicula.pDuracion
        lblSinopsis.Text = "Sinopsis: " & pelicula.pSinopsis
        Dim img As Image = CType(My.Resources.ResourceManager.GetObject(pelicula.pUrlImagen), Image)
        PictureBox1.Image = img
        Me.pelicula = pelicula
        Me.Show()
    End Sub
    Private Sub btVenta_Click(sender As Object, e As EventArgs) Handles btVenta.Click
        VentaEntradas.Mostrar(pelicula)
    End Sub

End Class