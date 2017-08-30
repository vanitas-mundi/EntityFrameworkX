Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.Data.EntityFrameworkX.Core
Imports SSP.Data.EntityFrameworkX.Models.Core.Interfaces
Imports SSP.Data.EntityFrameworkX.Validators
Imports System.Data.Entity
Imports SSP.Data.EntityFrameworkX.Contexts.Core.Interfaces
#End Region

Namespace Repositories.Core.Interfaces

  '''<summary>Erweitere eine Klasse um Repository-Basisfunktionalität.</summary>
  Public Interface IRepositoryBase(Of TModel As {Class, New, IModelBase(Of TModel, TPropertyNames, TContext)} _
  , TPropertyNames As Structure, TContext As {DbContext, IContextBase(Of TContext)})

    Inherits IRepositoryReadonlyBase(Of TModel, TPropertyNames, TContext)

    '''<summary>Instanziert ein Objekt vom Typ TModel und liefert dieses zurück.</summary>
    Function Create() As TModel
    '''<summary>Fügt das angebene Objekt in die Datenbank ein.</summary>
    Function Insert(ByVal item As TModel) As Int64
    '''<summary>Fügt die angebenen Objekte in die Datenbank ein.</summary>
    Function InsertRange(ByVal items As IEnumerable(Of TModel)) As Int64
    '''<summary>Fügt das angebene Objekt in die Datenbank ein.</summary>
    Function Add(ByVal item As TModel) As Int64
    '''<summary>Fügt die angebenen Objekte in die Datenbank ein.</summary>
    Function AddRange(ByVal items As IEnumerable(Of TModel)) As Int64
    '''<summary>Aktualisiert das angebene Objekt in der Datenbank.</summary>
    Function Update(ByVal item As TModel) As Int64
    '''<summary>Aktualisiert die angebenen Objekte in der Datenbank.</summary>
    Function UpdateRange(ByVal items As IEnumerable(Of TModel)) As Int64
    '''<summary>Löscht das Objekt der angegebenen Id in der Datenbank.</summary>
    Function DeleteById(ByVal id As Int64) As Int64
    '''<summary>Löscht das angebene Objekt in der Datenbank.</summary>
    Function Delete(ByVal item As TModel) As Int64
    '''<summary>Löscht die angebenen Objekte in der Datenbank.</summary>
    Function DeleteRange(ByVal items As IEnumerable(Of TModel)) As Int64
    '''<summary>Löscht das Objekt der angegebenen Id in der Datenbank.</summary>
    Function RemoveById(ByVal id As Int64) As Int64
    '''<summary>Löscht das angebene Objekt in der Datenbank.</summary>
    Function Remove(ByVal item As TModel) As Int64
    '''<summary>Löscht die angebenen Objekte in der Datenbank.</summary>
    Function RemoveRange(ByVal items As IEnumerable(Of TModel)) As Int64
    '''<summary>Liefert ein Objekt zur Validierung der Werte von Model-Eigenschaften.</summary>
    ReadOnly Property ModelValidator As ModelValidator(Of TModel, TPropertyNames, TContext)
  End Interface

End Namespace

