Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Data.Entity
Imports System.Reflection
Imports System.Collections.ObjectModel
Imports SSP.Data.EntityFrameworkX.Core
#End Region

Namespace Contexts.Core

	''' <summary>
	''' Stellt Context-Basisfunktionalität zur Verfügung
	''' </summary>
	Public Class ContextBase(Of TContext As DbContext)

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private _lastExecutedStatement As New Statement
		Private _dbSets As ReadOnlyDictionary(Of Type, DbSet)
		Private _instance As DbContext
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Public Sub New(ByVal instance As TContext)

			_instance = instance
			_instance.Configuration.LazyLoadingEnabled = False
			_instance.Configuration.AutoDetectChangesEnabled = False
			_instance.Database.Log = AddressOf OnParseStatementLog

			InitializeDbSets()
		End Sub
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		''' <summary>Liefert ein Dictionary mit allen DbSets.</summary>
		Public ReadOnly Property DbSets As ReadOnlyDictionary(Of Type, DbSet)
			Get
				Return _dbSets
			End Get
		End Property

		Public ReadOnly Property LastExecutedStatement As Statement
			Get
				Return _lastExecutedStatement
			End Get
		End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
		Private Sub OnParseStatementLog(s As String)

			Select Case True
				Case s.StartsWith("SELECT"), s.StartsWith("UPDATE"), s.StartsWith("INSERT"), s.StartsWith("DELETE")
					_lastExecutedStatement.ResetStatement()
					_lastExecutedStatement.CommandText = s
				Case s.StartsWith("-- p")
					_lastExecutedStatement.Parameters.Add(New StatementParameter(s))
			End Select
		End Sub
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
		Private Sub InitializeDbSets()
			Dim dbSets = New Dictionary(Of Type, DbSet)
			Dim result = _instance.GetType.GetProperties.OfType(Of PropertyInfo)
			Dim propertyInfos = result.Where(Function(pi) pi.PropertyType.Name.StartsWith("DbSet"))

			For Each pi In propertyInfos
				Dim value = pi.GetValue(_instance)
				Dim dbSet = _instance.Set(value.GetType)
				dbSets.Add(value.GetType, dbSet)
			Next pi

			_dbSets = New ReadOnlyDictionary(Of Type, DbSet)(dbSets)
		End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace


