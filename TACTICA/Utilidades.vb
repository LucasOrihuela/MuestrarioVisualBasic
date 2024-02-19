Imports System.Text.RegularExpressions
Public Class Utilidades

    Public Function ValidarEmail(ByVal txt As String) As Integer
        Dim email As String = txt.Trim() ' Analiza el texto recibido y elimina los espacios en blanco al inicio y al final

        ' Patrón de expresión regular para validar una dirección de correo electrónico
        Dim patronEmail As String = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"

        ' Verifica si el email ingresado coincide con el patrón de expresión regular
        If Regex.IsMatch(email, patronEmail) Then
            Return 1 ' Email válido
        Else
            Return -1 ' Email no válido
        End If
    End Function

End Class
