Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Text
#End Region

Namespace Core
	Public Class Statement

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private _parameters As New List(Of StatementParameter)
		Private _commandText As New StringBuilder
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Public Sub New()
		End Sub

		Public Sub New(ByVal commandText As String)
			_commandText = New StringBuilder(commandText)
		End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		'''<summary>Die Parameter des Statements.</summary>
		Public ReadOnly Property Parameters As List(Of StatementParameter)
			Get
				Return _parameters
			End Get
		End Property

		'''<summary>Das SQL-Kommando.</summary>
		Public Property CommandText As String
			Get
				Return _commandText.ToString
			End Get
			Set(value As String)
				_commandText = New StringBuilder(value)
			End Set
		End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		'''<summary>Setzt das Statement und die Parameter zurück.</summary>
		Public Sub ResetStatement()
			_commandText = New StringBuilder
			_parameters = New List(Of StatementParameter)
		End Sub

		'''<summary>Löst die Parameter auf und liefert das Statement.</summary>
		Public Function ResolveStatement() As String

			For i = _parameters.Count - 1 To 0 Step -1
				Dim p = _parameters.Item(i)
				_commandText.Replace(p.Name, p.Value)
			Next i
			Return _commandText.ToString
		End Function

		Public Overloads Function ToString(ByVal resolveParameters As Boolean) As String
			Return If(resolveParameters, ResolveStatement(), _commandText.ToString)
		End Function

		Public Overrides Function ToString() As String
			Return Me.ToString(True)
		End Function
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace
