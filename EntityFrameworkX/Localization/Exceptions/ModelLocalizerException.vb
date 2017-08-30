Option Explicit On
Option Infer On
Option Strict On

Namespace Localization.Exceptions

	Public Class ModelLocalizerException

		Inherits Exception

		Public Sub New(ByVal message As String)
			MyBase.New(message)
		End Sub
	End Class

End Namespace
