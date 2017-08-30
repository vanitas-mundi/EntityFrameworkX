Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace Core

	Public Class StatementParameter

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Public Sub New(ByVal s As String)
			ParseStringToParameter(s)
		End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		'''<summary>Name des Parameters.</summary>
		Public Property Name As String

		'''<summary>Wert des Parameters.</summary>
		Public Property Value As String

		'''<summary>Typ des Parameters.</summary>
		Public Property Type As String

		'''<summary>Null-Werte erlaubt.</summary>
		Public Property IsNullable As Boolean

		'''<summary>Maximale Länge des Parameters.</summary>
		Public Property Size As Int64
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
		Private Sub ParseStringToParameter(ByVal s As String)
			Dim parts = s.Split(":"c)
			_Name = parts.First.Replace("-- ", ":")

			parts = parts.Last.Split("("c)
			_Value = parts.First.Trim

			Dim attributes = parts.Last.Replace _
			("(", "").Replace(")", "").Replace(" ", "").Split _
			(","c).ToList.Select(Function(x) x.Split("="c)).Select _
			(Function(x) New With {.Name = x.First, .Value = x.Last}).ToList

			For Each attribute In attributes
				Dim p = Me.GetType.GetProperty(attribute.Name)
				p.SetValue(Me, Convert.ChangeType(attribute.Value, p.PropertyType))
			Next attribute
		End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		Public Overrides Function ToString() As String
			Return String.Concat(Me.Name, ":", Me.Value)
		End Function
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace
