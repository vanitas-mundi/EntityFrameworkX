Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports SSP.Data.EntityFrameworkX.Contexts.Core.Interfaces
Imports SSP.Data.EntityFrameworkX.Core
Imports SSP.Data.EntityFrameworkX.Repositories.Core.Interfaces
Imports SSP.Data.EntityFrameworkX.Models.Core.Interfaces
Imports SSP.Base.Etc.Lambda
Imports SSP.Base.ExtensionMethods
Imports SSP.Data.EntityFrameworkX.Validators
Imports SSP.Data.EntityFrameworkX.Validators.Interfaces
#End Region

Namespace Repositories.Core

  '''<summary>Stellt Repository-Basisfunktionalität zur Verfügung.</summary>
  Public Class RepositoryReadOnlyBase(Of TModel As {Class, New, IModelBase(Of TModel, TPropertyNames, TContext)} _
  , TPropertyNames As Structure, TContext As {DbContext, IContextBase(Of TContext)})

    Implements IRepositoryReadOnlyBase
    Implements IRepositoryReadOnlyBase(Of TModel, TPropertyNames, TContext)

#Region " --------------->> Implements IRepositoryBase "
    Private Function IRepositoryBase_AsQueryable(includes() As String) As IQueryable(Of Object) _
    Implements IRepositoryReadOnlyBase.AsQueryable

      Return Me.AsQueryable(includes)
    End Function

    Private Function IRepositoryBase_Exists(id As Int64) As Boolean _
    Implements IRepositoryReadOnlyBase.Exists
      Return Me.Exists(id)
    End Function

    Private Function IRepositoryBase_GetById(id As Int64) As Object _
    Implements IRepositoryReadOnlyBase.GetById
      Return Me.GetById(id)
    End Function

    Private Function IRepositoryBase_GetById(id As Int64, ByVal includes As String()) As Object _
    Implements IRepositoryReadOnlyBase.GetById
      Return Me.GetById(id, includes)
    End Function

    Private Function IRepositoryBase_GetByIds(ids As IEnumerable(Of Int64)) _
    As IQueryable(Of Object) Implements IRepositoryReadOnlyBase.GetByIds
      Return Me.GetByIds(ids)
    End Function

    Private Function IRepositoryBase_GetAll() As IQueryable(Of Object) _
    Implements IRepositoryReadOnlyBase.GetAll
      Return Me.GetAll
    End Function

    Private Function IRepositoryBase_AsQueryable() As IQueryable(Of Object) _
    Implements IRepositoryReadOnlyBase.AsQueryable
      Return Me.AsQueryable
    End Function

    Private Function IRepositoryBase_ExecuteStoredFunction(Of T) _
    (functionName As String, ParamArray functionParameters() As Object) As T _
    Implements IRepositoryReadOnlyBase.ExecuteStoredFunction

      Return Me.ExecuteStoredFunction(Of T)(functionName, functionParameters)
    End Function

    Private Function IRepositoryBase_ExecuteStatement(Of T) (ByVal statement as string) As T _
    Implements IRepositoryReadOnlyBase.ExecuteStatement

      Return Me.ExecuteStatement(Of T)(statement)
    End Function

    Private ReadOnly Property IRepositoryBase_LastExecutedStatement As Statement _
    Implements IRepositoryReadOnlyBase.LastExecutedStatement
      Get
        Return Me.LastExecutedStatement
      End Get
    End Property
#End Region

#Region " --------------->> Enumerationen der Klasse "
#End Region  '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
    Private _lastExecutedStatement As New Statement
#End Region  '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Protected ReadOnly Property Context As TContext
      Get
        Dim ctx = ContextManager.Instance.GetContext(Of TContext)
        _lastExecutedStatement = ctx.ContextBase.LastExecutedStatement
        Return ctx
      End Get
    End Property

    Public ReadOnly Property LastExecutedStatement As Statement _
    Implements IRepositoryReadOnlyBase(Of TModel, TPropertyNames, TContext).LastExecutedStatement
      Get
        Return _lastExecutedStatement
      End Get
    End Property
#End Region  '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region  '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
    Private Function GetExceptionMessage(ByVal ex As Exception) As String
      Return String.Concat(ex.InnerException.InnerException.Message _
      , vbCrLf, vbCrLf, "ExecutedStatement:", vbCrLf, Me.LastExecutedStatement.ToString)
    End Function

    '''<summary>
    ''' Aktualisiert die Felder Erfasst, ErfasstVon, GeaendertUserId und GeaendertAm,
    ''' wenn die Schnittstelle IModifiedUpdater implementiert wurde.
    '''</summary>
    Private Sub ExecuteModifiedUpdater(ByVal items As IEnumerable(Of TModel), ByVal state As EntityState)
      If (state = EntityState.Modified) OrElse (state = EntityState.Added) Then
        For Each item In items.OfType(Of IModifiedUpdater).ToList
          item.ManipulationUserId = ContextManager.Instance.LoginUserId
          item.ManipulationDate = DateTime.Now
          If state = EntityState.Added Then
            item.CreationUserId = item.ManipulationUserId
            item.CreationDate = item.ManipulationDate.Value
          End If
        Next item
      End If
    End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>Prüft, ob ein Objekt mit der angegebenen Id in der Datenbank existiert.</summary>
    Public Function Exists(id As Int64) As Boolean Implements IRepositoryReadOnlyBase(Of TModel, TPropertyNames, TContext).Exists
      Return Me.GetById(id) IsNot Nothing
    End Function

    '''<summary>Liefert das Objekt zur angegebenen Id.</summary>
    Public Function GetById(id As Int64) As TModel Implements IRepositoryReadOnlyBase(Of TModel, TPropertyNames, TContext).GetById
      Return Me.AsQueryable.FirstOrDefault(Function(item) item.RowId = id)
    End Function

    '''<summary>Liefert das Objekt zur angegebenen Id.</summary>
    Public Function GetById(id As Int64, ByVal includes As String()) As TModel _
    Implements IRepositoryReadOnlyBase(Of TModel, TPropertyNames, TContext).GetById
      Return Me.AsQueryable(includes).FirstOrDefault(Function(item) item.RowId = id)
    End Function

    '''<summary>Liefert die Objekt zu den angegebenen Ids.</summary>
    Public Function GetByIds(ids As IEnumerable(Of Int64)) As IQueryable(Of TModel) _
    Implements IRepositoryReadOnlyBase(Of TModel, TPropertyNames, TContext).GetByIds

      Return Me.AsQueryable.Where(Function(item) ids.Contains(item.RowId))
    End Function

    '''<summary>Liefert alle Objekte aus der Datenbank als IQueryable.</summary>
    Public Function GetAll() As IQueryable(Of TModel) _
    Implements IRepositoryReadOnlyBase(Of TModel, TPropertyNames, TContext).GetAll
      Return Me.AsQueryable
    End Function

    '''<summary>Liefert alle Objekte aus der Datenbank als IQueryable.</summary>
    Public Function AsQueryable() As IQueryable(Of TModel) _
    Implements IRepositoryReadOnlyBase(Of TModel, TPropertyNames, TContext).AsQueryable

      Return Me.Context.Set(Of TModel).AsNoTracking.AsQueryable
    End Function

    '''<summary>
    '''Liefert alle Objekte aus der Datenbank als IQueryable.
    '''Benötigte Includes werden als String-Array übergeben.
    '''</summary>
    Public Function AsQueryable(ByVal includes As String()) As IQueryable(Of TModel) _
    Implements IRepositoryReadOnlyBase(Of TModel, TPropertyNames, TContext).AsQueryable
      Dim result = Me.AsQueryable
      includes.ToList.ForEach(Sub(x) result = result.Include(x))
      Return result
    End Function

    '''<summary>Führt eine Stored-Function vom Typ T aus. 
    ''' Bsp.: ExecuteStoredFunction(Of String)("nv.GetValue", "param1") | 
    '''       ExecuteStoredFunction(Of String)("MD5", "Geheim")
    '''</summary>
    Public Function ExecuteStoredFunction(Of T) _
    (functionName As String, ParamArray functionParameters() As Object) As T _
    Implements IRepositoryReadOnlyBase(Of TModel, TPropertyNames, TContext).ExecuteStoredFunction

      Dim parmFormatString = ForEachIndex(0, functionParameters.Count - 1).Select _
      (Function(i) String.Format("'{0}'", functionParameters(i))).EnumerableJoin

      Dim functionStatement = String.Concat("SELECT ", functionName, "(", parmFormatString, ")")
      Return Context.Database.SqlQuery(Of T)(functionStatement).FirstOrDefault
    End Function

    '''<summary>Führt ein SQL-Stament aus.</summary>
    Public Function ExecuteStatement(Of T) (ByVal statement As string) As T _
    Implements IRepositoryReadOnlyBase(Of TModel, TPropertyNames, TContext).ExecuteStatement
      Return Context.Database.SqlQuery(Of T)(statement).FirstOrDefault
    End Function
#End Region  '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
