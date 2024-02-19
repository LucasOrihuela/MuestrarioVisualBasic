Imports System.Configuration
Imports System.Data.SqlClient

Public Class GestorConexion
    Public Shared Function ObtenerConexion() As SqlConnection
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("TacticaConexion").ConnectionString
        Return New SqlConnection(connectionString)
    End Function

End Class
