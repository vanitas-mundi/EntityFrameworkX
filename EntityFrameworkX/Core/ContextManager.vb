Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Data.Common
Imports System.Data.Entity
Imports SSP.Data.EntityFrameworkX.Contexts.Core.Interfaces
Imports SSP.Data.EntityFrameworkX.Contexts
Imports System.Collections.ObjectModel
#End Region

Namespace Core

	'''<summary>http://blog.devart.com/entity-framework-6-support-for-oracle-mysql-postgresql-sqlite-and-salesforce.html</summary>
	Public NotInheritable Class ContextManager

#Region " --------------->> Enumerationen der Klasse "
#End Region  '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private _contexts As New Dictionary(Of Type, DbContext)
		Private _connection As DbConnection
		Private _connectionString As String
		Private _configuration As DbConfiguration
		Private _loginUserId As Int64
		Private _isInitialized As Boolean
#End Region  '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Private Sub New()
		End Sub
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public Shared ReadOnly Property Instance As ContextManager= new ContextManager

		Public ReadOnly Property LoginUserId As Int64
			Get
				Return _loginUserId
			End Get
		End Property

		Public ReadOnly Property ContextTypes As Type()
			Get
				Return _contexts.Keys.OfType(Of Type).ToArray()
			End Get
		End Property

		Public ReadOnly Property Configuration As DbConfiguration
			Get
				Return _configuration
			End Get
		End Property

		Public ReadOnly Property Connection As DbConnection
			Get
				Return _connection
			End Get
		End Property

		Public ReadOnly Property ConnectionString As String
			Get
				Return _connectionString
			End Get
		End Property

		Public Property IsInitialized As Boolean
			Get
				Return _isInitialized
			End Get
			set	(value As Boolean)
				 _isInitialized = value
			End Set
		End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
		Private Sub InitializeContexts()
			GetContextTypes.ForEach(Sub(t) _contexts.Add(t, Nothing))
			IsInitialized = true
		End Sub

		Private Function GetContextTypes() As List(Of Type)
			Dim contextTypeName = GetType(DbContext).FullName

			Return Reflection.Assembly.GetExecutingAssembly.GetTypes.Where _
			(Function(t) (t.BaseType IsNot Nothing) _
			AndAlso (t.BaseType.FullName = contextTypeName)).ToList
		End Function
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		'''<summary>Setzt die Entity-Framework-DbConfiguration und initialisiert das Context-Dictionary</summary>
		Public Sub Initialize(ByVal configuration As DbConfiguration,  ByVal connection As DbConnection, ByVal loginUserId As Int64)

			_loginUserId = loginUserId
			_configuration = configuration
			_connection = connection
			_connectionString = _connection.ConnectionString
			DbConfiguration.SetConfiguration(Me.Configuration)
			InitializeContexts()
		End Sub

		'''<summary>Setzt die Entity-Framework-DbConfiguration und initialisiert das Context-Dictionary</summary>
		Public Sub SetDbConfiguration(ByVal configuration As DbConfiguration , ByVal connection As DbConnection, ByVal loginUserId As Int64)

			Initialize(configuration, connection, loginUserId)
		End Sub

		'''<summary>Liefert einen neuen Context vom Typ DbContext.</summary>
		Friend Function CreateContext(Of TDbContext As DbContext)() As TDbContext

			Me.Connection.ConnectionString = Me.ConnectionString

			Return DirectCast(Activator.CreateInstance (GetType(TDbContext), New Object() {Me.Connection}), TDbContext)
		End Function

		'''<summary>
		'''Liefert den Context zum angegebenen Typ DbContext. 
		'''Darf nicht in einem Using verwendet werden. 
		'''Weil danach der Context seine Dispose-Methode aufruft.
		'''Für Using sollte CreateContext benutzt werden.
		'''</summary>
		Friend Function GetContext(Of TDbContext As DbContext)() As TDbContext

			Dim key = GetType(TDbContext)
			If _contexts.Item(key) Is Nothing Then
				_contexts.Item(key) = CreateContext(Of TDbContext)()
			End If

			Return DirectCast(_contexts.Item(key), TDbContext)
		End Function

		Friend Function GetContextByModel(Of TModel)() As DbContext

			For Each contextType In _contexts.Keys

				Dim context = DirectCast(Activator.CreateInstance _
				(contextType, New Object() {Me.Connection}), DbContext)

				Dim contextBase = context.GetType.InvokeMember _
				("ContextBase", Reflection.BindingFlags.InvokeMethod, Nothing, context, New Object() {})

				Dim dbSets = DirectCast(contextBase.GetType.InvokeMember _
				("DbSets", Reflection.BindingFlags.GetProperty, Nothing, contextBase, New Object() {}) _
				, ReadOnlyDictionary(Of Type, DbSet))

				If dbSets.Keys.ToList.Any(Function(x) x.FullName.Contains(GetType(TModel).Name)) Then
					Return context
				End If
			Next contextType

			Return Nothing
		End Function
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace
