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
	Public Class RepositoryBase(Of TModel As {Class, New, IModelBase(Of TModel, TPropertyNames, TContext)} _
	, TPropertyNames As Structure, TContext As {DbContext, IContextBase(Of TContext)})

    Inherits RepositoryReadOnlyBase(Of TModel, TPropertyNames, TContext)

    Implements IRepositoryBase
		Implements IRepositoryBase(Of TModel, TPropertyNames, TContext)

#Region " --------------->> Implements IRepositoryBase "
		Private Function IRepositoryBase_Create() As Object Implements IRepositoryBase.Create

			Return Me.Create
		End Function

		Private Function IRepositoryBase_AsQueryable(includes() As String) As IQueryable(Of Object) _
		Implements IRepositoryBase.AsQueryable

			Return Me.AsQueryable(includes)
		End Function

		Private Function IRepositoryBase_Exists(id As Int64) As Boolean _
		Implements IRepositoryBase.Exists
			Return Me.Exists(id)
		End Function

		Private Function IRepositoryBase_GetById(id As Int64) As Object _
		Implements IRepositoryBase.GetById
			Return Me.GetById(id)
		End Function

		Private Function IRepositoryBase_GetById(id As Int64, ByVal includes As String()) As Object _
		Implements IRepositoryBase.GetById
			Return Me.GetById(id, includes)
		End Function

		Private Function IRepositoryBase_GetByIds(ids As IEnumerable(Of Int64)) _
		As IQueryable(Of Object) Implements IRepositoryBase.GetByIds
			Return Me.GetByIds(ids)
		End Function

		Private Function IRepositoryBase_Insert(item As Object) As Int64 _
		Implements IRepositoryBase.Insert
			Return Me.Insert(DirectCast(item, TModel))
		End Function

		Private Function IRepositoryBase_InsertRange(items As IEnumerable(Of Object)) As Int64 _
		Implements IRepositoryBase.InsertRange
			Return Me.InsertRange(items.OfType(Of TModel))
		End Function

		Private Function IRepositoryBase_Add(item As Object) As Int64 _
		Implements IRepositoryBase.Add
			Return Me.Add(DirectCast(item, TModel))
		End Function

		Private Function IRepositoryBase_AddRange(items As IEnumerable(Of Object)) As Int64 _
		Implements IRepositoryBase.AddRange
			Return Me.AddRange(items.OfType(Of TModel))
		End Function

		Private Function IRepositoryBase_Update(item As Object) As Int64 _
		Implements IRepositoryBase.Update
			Return Me.Update(DirectCast(item, TModel))
		End Function

		Private Function IRepositoryBase_UpdateRange(items As IEnumerable(Of Object)) As Int64 _
		Implements IRepositoryBase.UpdateRange
			Return Me.UpdateRange(items.OfType(Of TModel))
		End Function

		Private Function IRepositoryBase_DeleteById(id As Int64) As Int64 _
		Implements IRepositoryBase.DeleteById
			Return Me.DeleteById(id)
		End Function

		Private Function IRepositoryBase_Delete(item As Object) As Int64 _
		Implements IRepositoryBase.Delete
			Return Me.Delete(DirectCast(item, TModel))
		End Function

		Private Function IRepositoryBase_DeleteRange(items As IEnumerable(Of Object)) As Int64 _
		Implements IRepositoryBase.DeleteRange
			Return Me.DeleteRange(items.OfType(Of TModel))
		End Function

		Private Function IRepositoryBase_RemoveById(id As Int64) As Int64 _
		Implements IRepositoryBase.RemoveById
			Return Me.RemoveById(id)
		End Function

		Private Function IRepositoryBase_Remove(item As Object) As Int64 _
		Implements IRepositoryBase.Remove
			Return Me.Remove(DirectCast(item, TModel))
		End Function

		Private Function IRepositoryBase_RemoveRange(items As IEnumerable(Of Object)) As Int64 _
		Implements IRepositoryBase.RemoveRange
			Return Me.RemoveRange(items.OfType(Of TModel))
		End Function

		Private Function IRepositoryBase_GetAll() As IQueryable(Of Object) _
		Implements IRepositoryBase.GetAll
			Return Me.GetAll
		End Function

		Private Function IRepositoryBase_AsQueryable() As IQueryable(Of Object) _
		Implements IRepositoryBase.AsQueryable
			Return Me.AsQueryable
		End Function

		Private Function IRepositoryBase_ExecuteStoredFunction(Of T) _
		(functionName As String, ParamArray functionParameters() As Object) As T _
		Implements IRepositoryBase.ExecuteStoredFunction
			Return Me.ExecuteStoredFunction(Of T)(functionName, functionParameters)
		End Function

        Private Function IRepositoryBase_ExecuteStatement(Of T) (ByVal statement As string) As T
            Return Me.ExecuteStatement(Of T)(statement)
        End Function

		Private ReadOnly Property IRepositoryBase_LastExecutedStatement As Statement _
		Implements IRepositoryBase.LastExecutedStatement
			Get
				Return Me.LastExecutedStatement
			End Get
		End Property

		Private ReadOnly Property IRepositoryBase_ModelValidator As IModelValidator _
		Implements IRepositoryBase.ModelValidator
			Get
				Return Me.ModelValidator
			End Get
		End Property
#End Region

#Region " --------------->> Enumerationen der Klasse "
#End Region  '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private _lastExecutedStatement As New Statement
		Private _modelValidator As ModelValidator(Of TModel, TPropertyNames, TContext)
#End Region  '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Public Sub New()
			_modelValidator = New ModelValidator(Of TModel, TPropertyNames, TContext)(Me)
		End Sub
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "

    Protected ReadOnly Property ContextDml As TContext
			Get
				Dim ctx = ContextManager.Instance.CreateContext(Of TContext)
				_lastExecutedStatement = ctx.ContextBase.LastExecutedStatement
				Return ctx
			End Get
		End Property

		'''<summary>Liefert ein Objekt zur Validierung der Werte von Model-Eigenschaften.</summary>
		Public ReadOnly Property ModelValidator As ModelValidator(Of TModel, TPropertyNames, TContext) _
		Implements IRepositoryBase(Of TModel, TPropertyNames, TContext).ModelValidator
			Get
				Return _modelValidator
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

		Private Function SetStateTo(ByVal items As IEnumerable(Of TModel), ByVal state As EntityState) As Int64

			Using context = Me.ContextDml
				items.ToList.ForEach(Sub(x) context.Entry(x).State = state)

				Try
					ExecuteModifiedUpdater(items, state)
					context.SaveChanges()
					Return items.Count
				Catch ex As DbUpdateConcurrencyException
					'Items konnten nicht in der DB aktualisiert werden
					'z.B. wenn ein Objekt aktualisiert werden soll, dessen
					'Eigenschaften zuvor nicht geändert worden sind.
					Return -1
				Catch ex As DbUpdateException
					'Prüfen auf Constraint Violation
					If ex.InnerException.InnerException.Message.Contains("foreign key constraint fails") Then
						Throw New Exceptions.DbConstraintViolationException(ex, state, Me.LastExecutedStatement)
					Else
						Throw New Exception(GetExceptionMessage(ex), ex)
					End If
				Catch ex As Exception
					Throw New Exception(GetExceptionMessage(ex), ex)
				End Try
			End Using
		End Function
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		'''<summary>Instanziert ein Objekt vom Typ TModel und liefert dieses zurück.</summary>
		Public Function Create() As TModel Implements IRepositoryBase(Of TModel, TPropertyNames, TContext).Create

			Return New TModel
		End Function

    '''<summary>Fügt das angebene Objekt in die Datenbank ein.</summary>
    Public Function Insert(item As TModel) As Int64 _
		Implements IRepositoryBase(Of TModel, TPropertyNames, TContext).Insert
			Return Add(item)
		End Function

		'''<summary>Fügt die angebenen Objekte in die Datenbank ein.</summary>
		Public Function InsertRange(items As IEnumerable(Of TModel)) As Int64 _
		Implements IRepositoryBase(Of TModel, TPropertyNames, TContext).InsertRange
			Return AddRange(items)
		End Function

		'''<summary>Fügt das angebene Objekt in die Datenbank ein.</summary>
		Public Overridable Function Add(ByVal item As TModel) As Int64 _
		Implements IRepositoryBase(Of TModel, TPropertyNames, TContext).Add

			Return AddRange(New TModel() {item})
		End Function

		'''<summary>Fügt die angebenen Objekte in die Datenbank ein.</summary>
		Public Overridable Function AddRange(ByVal items As IEnumerable(Of TModel)) As Int64 _
		Implements IRepositoryBase(Of TModel, TPropertyNames, TContext).AddRange

			Return SetStateTo(items, EntityState.Added)
		End Function

		'''<summary>Aktualisiert das angebene Objekt in der Datenbank.</summary>
		Public Overridable Function Update(ByVal item As TModel) As Int64 _
		Implements IRepositoryBase(Of TModel, TPropertyNames, TContext).Update

			Return UpdateRange(New TModel() {item})
		End Function

		'''<summary>Aktualisiert die angebenen Objekte in der Datenbank.</summary>
		Public Overridable Function UpdateRange(ByVal items As IEnumerable(Of TModel)) As Int64 _
		Implements IRepositoryBase(Of TModel, TPropertyNames, TContext).UpdateRange

			Return SetStateTo(items, EntityState.Modified)
		End Function

		'''<summary>Löscht das Objekt der angegebenen Id in der Datenbank.</summary>
		Public Function DeleteById(id As Int64) As Int64 _
		Implements IRepositoryBase(Of TModel, TPropertyNames, TContext).DeleteById
			Return RemoveById(id)
		End Function

		'''<summary>Löscht das angebene Objekt in der Datenbank.</summary>
		Public Overridable Function Delete(ByVal item As TModel) As Int64 _
		Implements IRepositoryBase(Of TModel, TPropertyNames, TContext).Delete
			Return RemoveRange(New TModel() {item})
		End Function

		'''<summary>Löscht die angebenen Objekte in der Datenbank.</summary>
		Public Overridable Function DeleteRange(ByVal items As IEnumerable(Of TModel)) As Int64 _
		Implements IRepositoryBase(Of TModel, TPropertyNames, TContext).DeleteRange
			Return SetStateTo(items, EntityState.Deleted)
		End Function

		'''<summary>Löscht das Objekt der angegebenen Id in der Datenbank.</summary>
		Public Function RemoveById(id As Int64) As Int64 _
		Implements IRepositoryBase(Of TModel, TPropertyNames, TContext).RemoveById
			Return Remove(GetById(id))
		End Function

		'''<summary>Löscht das angebene Objekt in der Datenbank.</summary>
		Public Function Remove(item As TModel) As Int64 _
		Implements IRepositoryBase(Of TModel, TPropertyNames, TContext).Remove
			Return RemoveRange(New TModel() {item})
		End Function

		'''<summary>Löscht die angebenen Objekte in der Datenbank.</summary>
		Public Function RemoveRange(items As IEnumerable(Of TModel)) As Int64 _
		Implements IRepositoryBase(Of TModel, TPropertyNames, TContext).RemoveRange
			Return SetStateTo(items, EntityState.Deleted)
		End Function
#End Region  '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
