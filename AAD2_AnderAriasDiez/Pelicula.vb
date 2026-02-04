Public Class Pelicula
    'Atributos
    Private titulo As String
    Private estreno As Integer
    Private duracion As Integer
    Private sinopsis As String
    Private urlImagen As String
    Private entradasDisponibles As Integer
    'Constructor
    Public Sub New(titulo As String, estreno As Integer, duracion As Integer, sinopsis As String, urlImagen As String, entradasDisponibles As Integer)
        Me.titulo = titulo
        Me.estreno = estreno
        Me.duracion = duracion
        Me.sinopsis = sinopsis
        Me.urlImagen = urlImagen
        Me.entradasDisponibles = entradasDisponibles
    End Sub
    'Getters y Setters
    Public Property pTitulo() As String
        Get
            Return titulo
        End Get
        Set(ByVal value As String)
            titulo = value
        End Set
    End Property
    Public Property pEstreno() As Integer
        Get
            Return estreno
        End Get
        Set(ByVal value As Integer)
            estreno = value
        End Set
    End Property
    Public Property pDuracion() As Integer
        Get
            Return duracion
        End Get
        Set(ByVal value As Integer)
            duracion = value
        End Set
    End Property
    Public Property pSinopsis() As String
        Get
            Return sinopsis
        End Get
        Set(ByVal value As String)
            sinopsis = value
        End Set
    End Property
    Public Property pUrlImagen() As String
        Get
            Return urlImagen
        End Get
        Set(ByVal value As String)
            urlImagen = value
        End Set
    End Property
    Public Property pEntradasDisponibles() As Integer
        Get
            Return entradasDisponibles
        End Get
        Set(ByVal value As Integer)
            entradasDisponibles = value
        End Set
    End Property
End Class
