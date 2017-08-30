Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace Validators.Exceptions

    Public Class ModelValidatorException

        Inherits Exception

        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub

    End Class

End Namespace

