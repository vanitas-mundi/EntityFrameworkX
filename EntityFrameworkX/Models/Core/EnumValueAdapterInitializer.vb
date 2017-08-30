Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.Data.EntityFrameworkX.Models.Core
#End Region

Namespace Models.Core
	Public Class EnumValueAdapterInitializer(Of TEnum As Structure)

		Inherits Dictionary(Of TEnum, DisplayDatabaseValue)

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		'''<summary>Verwenden wenn DisplayString und DatabaseString und Value identisch sind.</summary>
		Public Sub AddToDictionary(ByVal value As TEnum)
			Me.Add(value, New DisplayDatabaseValue(value.ToString, value.ToString))
		End Sub

		'''<summary>Verwenden wenn DisplayString und DatabaseString identisch sind. </summary>
		Public Sub AddToDictionary(ByVal value As TEnum, ByVal displayString As String)
			Me.Add(value, New DisplayDatabaseValue(displayString, displayString))
		End Sub

		'''<summary>Verwenden wenn DisplayString und DatabaseString nicht identisch sind. </summary>
		Public Sub AddToDictionary(ByVal value As TEnum _
		, ByVal displayString As String, ByVal databaseString As String)
			Me.Add(value, New DisplayDatabaseValue(displayString, databaseString))
		End Sub
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace
